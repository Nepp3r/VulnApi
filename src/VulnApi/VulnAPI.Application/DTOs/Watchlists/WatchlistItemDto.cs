using System;

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
