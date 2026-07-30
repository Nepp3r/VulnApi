using System;
using System.Threading;
using System.Threading.Tasks;
using VulnAPI.Application.DTOs.Users;
using VulnAPI.Application.Interfaces;
using VulnAPI.Application.Mappings;
using VulnAPI.Domain.User;
using VulnAPI.Domain.User.ValueObjects;

namespace VulnAPI.Application.Services.Users
{
    public class UserService
    {
        private readonly IVulnApiDbContext _dbContext;
        private readonly UserLookupService _userLookupService;
        public UserService(IVulnApiDbContext dbContext, UserLookupService userLookupService)
        {
            _dbContext = dbContext;
            _userLookupService = userLookupService;
        }
        public async Task<UserDto> GetUserByIdAsync(string userId, CancellationToken ct = default)
        {
            User user = await _userLookupService.GetUserByIdAsync(userId, ct);
            return UserMappings.ToDto(user);
        }
        public async Task UpdateUserAsync(UpdateUserDto userData, CancellationToken ct = default)
        {
            User user = await _userLookupService.GetUserByIdAsync(userData.UserId, ct);

            DisplayName? displayName = string.IsNullOrEmpty(userData.DisplayName) ? null : DisplayName.Create(userData.DisplayName);
            UniqueName? uniqueName = string.IsNullOrEmpty(userData.UniqueName) ? null : UniqueName.Create(userData.UniqueName);
            Email? email = string.IsNullOrEmpty(userData.Email) ? null : Email.Create(userData.Email);

            user.Update(displayName, uniqueName, email);
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task DeleteUserByIdAsync(string userId, CancellationToken ct = default)
        {
            User user = await _userLookupService.GetUserByIdAsync(userId, ct);
            user.Delete();
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task<Guid> CreateUserAsync(CreateUserDto userData, CancellationToken ct = default)
        {
            DisplayName displayName = DisplayName.Create(userData.DisplayName);
            UniqueName uniqueName = UniqueName.Create(userData.UniqueName);
            Email email = Email.Create(userData.Email);
            Role role = Enum.Parse<Role>(userData.Role);

            User user = User.Create(displayName, uniqueName, email, role);
            await _dbContext.Users.AddAsync(user, ct);
            await _dbContext.SaveChangesAsync(ct);
            return user.Id;
        }
        public async Task FollowUserByIdAsync(string userId, string userToFollowId, CancellationToken ct = default)
        {
            User user = await _userLookupService.GetUserByIdAsync(userId, ct);
            User userToFollow = await _userLookupService.GetUserByIdAsync(userToFollowId, ct);
            user.Follow(userToFollow.Id);
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task UnfollowUserByIdAsync(string userId, string userToFollowId, CancellationToken ct = default)
        {
            User user = await _userLookupService.GetUserByIdAsync(userId, ct);
            User userToFollow = await _userLookupService.GetUserByIdAsync(userToFollowId, ct);
            user.Unfollow(userToFollow.Id);
            await _dbContext.SaveChangesAsync(ct);
        }
    }
}
