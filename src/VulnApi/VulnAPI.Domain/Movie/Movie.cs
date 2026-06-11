using System;
using System.Collections.Generic;
using System.Linq;

namespace VulnAPI.Domain.Movie
{
    public class Movie
    {
        private HashSet<Genre> _genres { get; set; } = new();

        private Movie() { }

        public static Movie Create(string title, string description, string author, DateTime releaseDate, HashSet<Genre> genres)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required", nameof(title));

            return new Movie
            {
                Title = title,
                Description = description,
                Author = author,
                ReleaseDate = releaseDate,
                Deleted = false,
                _genres = genres
            };
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public bool Deleted { get; private set; }
        public IReadOnlyCollection<Genre> Genres => _genres.AsReadOnly();
        public void Delete()
        {
            if (Deleted)
                throw new InvalidOperationException("Movie already has been deleted");
            Deleted = true;
        }
        public void Restore()
        {
            if (!Deleted)
                throw new InvalidOperationException("Movie is not deleted");
            Deleted = false;
        }
    }
}
