using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VulnAPI.Application.DTOs.Users;
using VulnAPI.Application.Interfaces;

namespace VulnAPI.Application.Services
{
    public class UserService
    {
        private readonly IVulnApiDbContext _context;
        public async Task<UserDto> GetUserByIdAsync(Guid userId)
        {

        }
        public async Task UpdateUserAsync(UserDto userData)
        {

        }
        public async Task DeleteUserByIdAsync(Guid userId)
        {

        }
        public async Task<UserDto> CreateUserAsync(UserDto userData)
        {

        }
        public async Task FollowUserAsync(Guid userId, Guid userToFollowId)
        {

        }
        public async Task UnfollowUserAsync(Guid userId, Guid userToFollowId)
        {

        }
    }
}
