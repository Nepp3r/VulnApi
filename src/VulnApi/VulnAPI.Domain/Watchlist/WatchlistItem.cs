using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Domain.Watchlist
{
    public class WatchlistItem
    {
        public Guid Owner { get; set; }
        public int MovieId { get; set; }
        public DateTime AddedAt { get; set; }
        public WatchStatus WatchStatus { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
    }
}
