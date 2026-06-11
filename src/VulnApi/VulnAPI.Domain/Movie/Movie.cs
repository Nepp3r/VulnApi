using System;
using System.Collections.Generic;
using System.Linq;

namespace VulnAPI.Domain.Movie
{
    public class Movie
    {
        private HashSet<Genre> _genres { get; set; } = new();

        private Movie() { }

        public static Movie Create(string title, string description, DateTime releaseDate, HashSet<Genre> genres)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required", nameof(title));

            return new Movie
            {
                Title = title,
                Description = description,
                ReleaseDate = releaseDate
                _genres = genres
            };
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public IReadOnlyCollection<Genre> Genres => _genres.AsReadOnly();
    }
}
