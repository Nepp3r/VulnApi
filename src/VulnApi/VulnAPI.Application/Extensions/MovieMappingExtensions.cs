using System;
using System.Linq;
using VulnAPI.Application.DTOs.Movie;
using VulnAPI.Application.DTOs.Movies;
using VulnAPI.Domain.Movie;

namespace VulnAPI.Application.Extensions
{
    public static class MovieMappingExtensions
    {
        public static Movie ToMovieObject(this AddMovieDto data)
        {
            return Movie.Create(data.Title, data.Description, data.Author, DateTime.Parse(data.ReleaseDate), data.Genres.Select(g => (Genre)Enum.Parse(typeof(Genre), g)).ToHashSet());
        }
        public static Movie UpdateFromDto(this Movie movie, UpdateMovieDto data)
        {
            return movie.Update(data.Title, data.Description, data.Author, DateTime.Parse(data.ReleaseDate), data.Genres
                                                                                                .Select(g => (Genre)Enum.Parse(typeof(Genre), g))
                                                                                                .ToHashSet());
        }
        public static MovieDto ToDto(this Movie movie, int addedToWatchList)
        {
            return new MovieDto {Title = movie.Title, Description = movie.Description, Author = movie.Author, ReleaseDate = movie.ReleaseDate, AddedToWatchLists = addedToWatchList};
        }
    }
}
