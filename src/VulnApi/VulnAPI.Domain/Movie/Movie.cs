using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Domain.Movie
{
    public class Movie
    {
        private readonly List<Genre> _genres = new();

        private Movie() { }

        public static Movie Create(string title, string description, DateTime releaseDate)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required", nameof(title));

            return new Movie
            {
                Title = title,
                Description = description,
                ReleaseDate = releaseDate
            };
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string CoverImageUrl { get; private set; }
        public IReadOnlyCollection<Genre> Genres => _genres.AsReadOnly();

        public void AddGenre(Genre genre)
        {
            if (!_genres.Contains(genre))
                _genres.Add(genre);
        }

        public void SetCoverImage(string imageUrl)
        {
            CoverImageUrl = imageUrl;
        }
    }
}
