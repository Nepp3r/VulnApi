using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VulnAPI.Application.DTOs.Admin;
using VulnAPI.Application.Mappings;
using VulnAPI.Application.Interfaces;
using VulnAPI.Domain.Admin;
using VulnAPI.Domain.Post;
using VulnAPI.Domain.User;
using VulnAPI.Application.Services.Users;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace VulnAPI.Application.Services.Admin
{
    public class AdminService
    {
        private readonly IVulnApiDbContext _dbContext;
        private readonly UserLookupService _userLookupService;
        public AdminService(IVulnApiDbContext dbContext, UserLookupService userLookupService)
        {
            _dbContext = dbContext;
            _userLookupService = userLookupService;
        }
        public async Task BlockUserByIdAsync(string userId, string? reason, TimeSpan? duration, CancellationToken ct = default)
        {
            User? user = await _userLookupService.GetUserByIdAsync(userId, ct);
            if (user == null)
                throw new ApplicationException("User with given ID was not found");
            if (duration == null)
                user.Block(reason, duration);
            else
                user.BlockPermanently(reason);
            
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task DeletePostByIdAsync(int postId, CancellationToken ct = default)
        {
            Post? post = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId, ct);
            if (post == null)
                throw new ApplicationException("Post with given ID was not found");
            post.Delete();
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task<List<ReportDto>> GetPendingReports()
        {
            var reports = _dbContext.Reports
                .Where(r => r.Status != ReportStatus.Closed)
                .Select(r => AdminMappings.ToDTO(r))
                .ToList();
            return reports;
        }
        public async Task<List<ReportDto>> GetAllReports()
        {
            var reports = _dbContext.Reports
                .Select(r => AdminMappings.ToDTO(r))
                .ToList();
            return reports;
        }
    }
}
