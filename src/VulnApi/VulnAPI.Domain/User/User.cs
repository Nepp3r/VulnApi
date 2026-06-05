using System;
using System.Collections.Generic;
using System.Text;
using VulnAPI.Domain.Watchlist;

namespace VulnAPI.Domain.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public Role Role { get; set; }
        public ICollection<Guid> Followers { get; set; }
        public ICollection<Guid> Following { get; set; }
        public string Email { get; set; }
        public ICollection<WatchlistItem> Watchlist { get; set; }
    }
}
