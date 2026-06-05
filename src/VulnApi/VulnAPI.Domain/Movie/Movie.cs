using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Domain.Movie
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Genres> GenresList { get; set; }
        public byte[] CoverImage { get; set; }

    }
}
