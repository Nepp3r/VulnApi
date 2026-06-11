using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Application.DTOs.Movie
{
    public record MovieDto
    {
        string Title;
        DateTime ReleaseDate;
        string Author;
        string Description;
        int AddedToWatchLists;
    }
}
