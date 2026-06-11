using System.Collections.Generic;

namespace VulnAPI.Application.DTOs.Movies
{
    public record UpdateMovieDto
    {
        public int Id;
        public string Title;
        public string Description;
        public string Author;
        public string ReleaseDate;
        public List<string> Genres;
    }
}
