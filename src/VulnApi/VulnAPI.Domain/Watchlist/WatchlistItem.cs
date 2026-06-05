using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Domain.Watchlist
{
    public class WatchlistItem
    {
        public Guid Owner { get; private set; }
        public int MovieId { get; private set; }
        public DateTime AddedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public WatchStatus WatchStatus { get; private set; }
        public string Comment { get; private set; }
        public WatchlistItem() { }
        public void UpdateStatus(WatchStatus newStatus)
        {
            if (WatchStatus == newStatus)
                return;

            WatchStatus = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateComment(string comment)
        {
            Comment = comment;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
