using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Application.DTOs.Posts
{
    public class UpdatePostDto
    {
        public string? Title;
        public string Content;
        public uint PostId;
    }
}
