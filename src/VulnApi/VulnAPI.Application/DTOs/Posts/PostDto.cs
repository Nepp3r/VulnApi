using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Application.DTOs.Posts
{
    public record PostDto
    {
        string AuthorUniqueName;
        string title;
        string Text;
    }
}
