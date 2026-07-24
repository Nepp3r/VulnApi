using System;
using System.Linq;
using VulnAPI.Application.DTOs.Movie;
using VulnAPI.Application.DTOs.Movies;
using VulnAPI.Domain.Movie;

namespace VulnAPI.Application.Mappings
{
    public static class MovieMappings
    {
        public static Movie ToMovieObject(AddMovieDto data)
        {
            return Movie.Create(data.Title, data.Description, data.Author, DateTime.Parse(data.ReleaseDate), data.Genres.Select(g => (Genre)Enum.Parse(typeof(Genre), g)).ToHashSet());
        }
        public static Movie UpdateFromDto(Movie movie, UpdateMovieDto data)
        {
            return movie.Update(data.Title, data.Description, data.Author, DateTime.Parse(data.ReleaseDate), data.Genres
                                                                                                .Select(g => (Genre)Enum.Parse(typeof(Genre), g))
                                                                                                .ToHashSet());
        }
        public static MovieDto ToDto(Movie movie, int addedToWatchList)
        {
            return new MovieDto {Title = movie.Title, Description = movie.Description, Author = movie.Author, ReleaseDate = movie.ReleaseDate, AddedToWatchLists = addedToWatchList};
        }
    }
}
