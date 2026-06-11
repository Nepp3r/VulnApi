using Microsoft.EntityFrameworkCore;
using System;
using VulnAPI.Application.Interfaces;
using VulnAPI.Domain.Admin;
using VulnAPI.Domain.Movie;
using VulnAPI.Domain.Post;
using VulnAPI.Domain.User;
using VulnAPI.Domain.User.Profile;
using VulnAPI.Domain.Watchlist;

namespace VulnAPI.Infrastructure
{
    public class VulnApiDbContext : DbContext, IVulnApiDbContext
    {
        public DbSet<User> Users => throw new NotImplementedException();

        public DbSet<Post> Posts => throw new NotImplementedException();

        public DbSet<WatchlistItem> WatchlistItems => throw new NotImplementedException();

        public DbSet<Movie> Movies => throw new NotImplementedException();

        public DbSet<Follow> Follows => throw new NotImplementedException();

        public DbSet<Profile> Profiles => throw new NotImplementedException();

        public DbSet<Report> Reports => throw new NotImplementedException();
    }
}
