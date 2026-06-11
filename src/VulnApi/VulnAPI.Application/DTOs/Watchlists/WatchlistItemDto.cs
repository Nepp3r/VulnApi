using System;
using System.Collections.Generic;
using System.Text;
using VulnAPI.Domain.Watchlist;

namespace VulnAPI.Application.DTOs.Watchlists
{
    public record WatchlistItemDto
    {
        int MovieId;
        DateTime AddedAt;
        DateTime UpdatedAt;
        string WatchStatus;
        string Comment;
    }
}
