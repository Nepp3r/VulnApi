using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Application.DTOs.Posts
{
    public record CreatePostDto
    {
        public string AuthorId;
        public string? Title;
        public string Content;
        public uint? ParentPostId;
    }
}
