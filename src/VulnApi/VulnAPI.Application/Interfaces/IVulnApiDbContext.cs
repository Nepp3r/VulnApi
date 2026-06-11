using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VulnAPI.Domain.Admin;
using VulnAPI.Domain.Movie;
using VulnAPI.Domain.Post;
using VulnAPI.Domain.User;
using VulnAPI.Domain.User.Profile;
using VulnAPI.Domain.Watchlist;

namespace VulnAPI.Application.Interfaces
{
    public interface IVulnApiDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Post> Posts { get; }
        DbSet<WatchlistItem> WatchlistItems{ get; }
        DbSet<Movie> Movies { get; }
        DbSet<Follow> Follows { get; }
        DbSet<Profile> Profiles { get; }
        DbSet<Report> Reports { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
