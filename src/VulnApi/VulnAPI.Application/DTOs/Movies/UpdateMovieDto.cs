using System;
using System.Collections.Generic;
using System.Text;

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
