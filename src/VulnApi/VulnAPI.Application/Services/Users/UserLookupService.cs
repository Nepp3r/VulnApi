using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VulnAPI.Application.Interfaces;
using VulnAPI.Domain.User;
using VulnAPI.Domain.User.ValueObjects;

namespace VulnAPI.Application.Services.Users
{
    public sealed class UserLookupService
    {
        private readonly IVulnApiDbContext _dbContext;
        public UserLookupService(IVulnApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByUniqueNameAsync(string uniqueName, CancellationToken ct = default)
        {
            var name = UniqueName.Create(uniqueName);
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UniqueName.Equals(name), ct);
            if (user == default)
                throw new KeyNotFoundException("No user with such unique name was found");
            return user;
        }
        public async Task<User> GetUserByIdAsync(string id, CancellationToken ct = default)
        {
            if (Guid.TryParse(id, out var _))
                throw new ArgumentException("Given user Id is not a valid id");
            var user = await _dbContext.Users.FindAsync(id, ct);
            if (user == null)
                throw new KeyNotFoundException("No user with such id was found");
            return user;
        }
    }
}
