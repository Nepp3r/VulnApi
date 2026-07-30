using System;
using System.Collections.Generic;
using System.Text;
using VulnAPI.Application.DTOs.Users;
using VulnAPI.Domain.User;

namespace VulnAPI.Application.Mappings
{
    public static class UserMappings
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto {
                DisplayName = user.DisplayName.Value, 
                UniqueName = user.UniqueName.Value, 
                Role = user.Role.ToString(), 
                Email = user.Email.Value, 
                Deleted = user.Deleted, 
                Verified = user.Verified, 
                Blocked = user.ActiveBlock == null ? false : true, 
                Block = user.ActiveBlock == null ? null : new UserBlockDto { 
                                                                Reason = user.ActiveBlock.Reason, 
                                                                BlockedAt = user.ActiveBlock.BlockedAt.ToLongDateString(), 
                                                                Duration = user.ActiveBlock.Duration == null ? null : user.ActiveBlock.Duration.ToString() 
                                                              }
            };
        }
    }
}
