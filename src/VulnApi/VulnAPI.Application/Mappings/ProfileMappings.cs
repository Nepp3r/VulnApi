using System;
using System.Collections.Generic;
using System.Text;
using VulnAPI.Application.DTOs.Users.Profile;
using VulnAPI.Domain.User;
using VulnAPI.Domain.User.Profile;

namespace VulnAPI.Application.Mappings
{
    public static class ProfileMappings
    {
        public static ProfileDto ToDto(Profile profile, User user)
        {
            return new ProfileDto {
                OwnerId = user.Id.ToString(),
                OwnerUniqueName = user.UniqueName.Value, 
                OwnerDisplayName = user.DisplayName.Value, 
                FollowerCount = user.Followers.Count, 
                FollowingCount = user.Following.Count, 
                Description = profile.Description, 
                Visibility = profile.Visibility.ToString(),
                CreatedAt = profile.CreatedAt.ToString()
            };
        }
    }
}
