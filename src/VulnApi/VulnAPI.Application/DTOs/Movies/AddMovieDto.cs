using System;
using System.Collections.Generic;
using System.Text;
using VulnAPI.Domain.Movie;

namespace VulnAPI.Application.DTOs.Movies
{
    public record AddMovieDto
    {
        public List<string> Genres;
        public string Title;
        public string Description;
        public string ReleaseDate;
    }
}
