using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VulnAPI.Application.DTOs.Users.Profile;
using VulnAPI.Application.Interfaces;
using VulnAPI.Application.Mappings;
using VulnAPI.Domain.User;
using VulnAPI.Domain.User.Profile;

namespace VulnAPI.Application.Services.Users
{
    public class ProfileService
    {
        private readonly IVulnApiDbContext _dbContext;
        private readonly UserLookupService _userLookupService;
        public ProfileService(IVulnApiDbContext dbContext, UserLookupService userLookupService)
        {
            _dbContext = dbContext;
            _userLookupService = userLookupService;

        }
        public async Task<ProfileDto> GetUserProfileByUniqueNameAsync(string userUniqueName, CancellationToken ct = default)
        {
            var user = await _userLookupService.GetUserByUniqueNameAsync(userUniqueName, ct);
            if (user.Deleted || user.ActiveBlock != null)
                throw new UnauthorizedAccessException("Specified User Profile is not accessible");
            var profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.OwnerId == user.Id, ct);
            return ProfileMappings.ToDto(profile, user);
        }
        public async Task<ProfileDto> GetUserProfileByIdAsync(string userId, CancellationToken ct = default)
        {
            var user = await _userLookupService.GetUserByIdAsync(userId, ct);
            if (user.Deleted || user.ActiveBlock != null)
                throw new UnauthorizedAccessException("Specified User Profile is not accessible");
            var profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.OwnerId == user.Id, ct);
            return ProfileMappings.ToDto(profile, user);
        }
        public async Task UpdateProfileAsync(UpdateProfileDto profileData, CancellationToken ct = default)
        {
            if (profileData.OwnerId == null || !Guid.TryParse(profileData.OwnerId, out Guid guidId))
                throw new ArgumentException("Invalid profile owner id given");
            if (!Enum.TryParse(profileData.Visibility, out Visibility visibility))
                throw new ArgumentException("Invalid visibility value given");
            Profile? profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.OwnerId.ToString() == profileData.OwnerId, ct);
            profile.ChangeVisibility(visibility);
            profile.UpdateDescription(profileData.Description);
            await _dbContext.SaveChangesAsync(ct);
        }
    }
}
