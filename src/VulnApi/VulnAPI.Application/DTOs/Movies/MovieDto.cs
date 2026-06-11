using System;

namespace VulnAPI.Application.DTOs.Movie
{
    public record MovieDto
    {
        public string Title;
        public string Description;
        public string Author;
        public DateTime ReleaseDate;
        public int AddedToWatchLists;
    }
}
