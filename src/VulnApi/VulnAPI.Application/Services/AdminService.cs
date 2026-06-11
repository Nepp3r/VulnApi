using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VulnAPI.Application.DTOs.Admin;
using VulnAPI.Application.Extensions;
using VulnAPI.Application.Interfaces;
using VulnAPI.Domain.Admin;
using VulnAPI.Domain.Post;
using VulnAPI.Domain.User;

namespace VulnAPI.Application.Services
{
    public class AdminService
    {
        private readonly IVulnApiDbContext _dbContext;
        public AdminService(IVulnApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task BlockUserByIdAsync(Guid userId, string? reason, TimeSpan? duration)
        {
            User? user = _dbContext.Users.FirstOrDefault(u => u.Id.Equals(userId));
            if (user == null)
                throw new ApplicationException("User with given ID was not found");
            if (duration == null)
                user.Block(reason, duration);
            else
                user.BlockPermanently(reason);
            
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeletePostByIdAsync(int postId)
        {
            Post? post = _dbContext.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
                throw new ApplicationException("Post with given ID was not found");
            post.Delete();
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<ReportDto>> GetPendingReportsAsync()
        {
            var reports = _dbContext.Reports
                .Where(r => r.Status != ReportStatus.Closed)
                .Select(r => r.ToDTO())
                .ToList();
            return reports;
        }
        public async Task<List<ReportDto>> GetAllReportsAsync()
        {
            var reports = _dbContext.Reports
                .Select(r => r.ToDTO())
                .ToList();
            return reports;
        }
    }
}
