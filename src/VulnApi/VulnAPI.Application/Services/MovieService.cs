using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VulnAPI.Application.DTOs.Movies;
using VulnAPI.Application.Extensions;
using VulnAPI.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using VulnAPI.Application.DTOs.Movie;
using System.Collections.Generic;

namespace VulnAPI.Application.Services
{
    public class MovieService
    {
        private readonly IVulnApiDbContext _dbContext;
        public MovieService(IVulnApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MovieDto> GetMovieByIdAsync(int movieId, CancellationToken ct = default)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId, ct);
            if (movie is null)
                throw new KeyNotFoundException("No movie with such Id was found");
            int addedToWatchLists = await _dbContext.WatchlistItems.CountAsync(w => w.MovieId == movieId, ct);
            return movie.ToDto(addedToWatchLists);
        }
        public async Task AddMovieAsync(AddMovieDto movieData, CancellationToken ct = default)
        {
            var movies = _dbContext.Movies;
            if (movies.FirstOrDefault(m => m.Title == movieData.Title) != default)
                throw new ApplicationException("There already is a movie with this title");
            await movies.AddAsync(movieData.ToMovieObject());
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task UpdateMovieAsync(UpdateMovieDto movieData, CancellationToken ct = default)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == movieData.Id);
            if(movie is null)
                throw new KeyNotFoundException("No movie with such Id was found");
            movie.UpdateFromDto(movieData);
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task DeleteMovieAsync(int movieId, CancellationToken ct = default) {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId, ct);
            if (movie is null)
                throw new KeyNotFoundException("No movie with such Id was found");
            movie.Delete();
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task RestoreMovieAsync(int movieId, CancellationToken ct = default)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId, ct);
            if (movie is null)
                throw new KeyNotFoundException("No movie with such Id was found");
            movie.Restore();
            await _dbContext.SaveChangesAsync(ct);
        }
    }
}
