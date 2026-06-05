using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Domain.Post
{
    public class Post
    {
        public Guid Author { get; set; }
        public int PostId { get; set; }
        public int ParentPostId { get; set; }
        public string Message { get; set; }
        public string Titile { get; set; }
        public DateTime Date { get; set; }
    }
}
