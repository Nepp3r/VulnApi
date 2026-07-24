using System;
using System.Collections.Generic;
using System.Text;
using VulnAPI.Application.DTOs.Posts;
using VulnAPI.Domain.Post;

namespace VulnAPI.Application.Mappings
{
    public static class PostMappings
    {
        public static PostDto ToDto(Post post, string authorUniqueName, string authorDisplayName)
        {
            return new PostDto { Id = post.Id, AuthorUniqueName = authorUniqueName, AuthorDisplayName = authorDisplayName, Title = post.Title, AuthorId = post.AuthorId.ToString(), Content = post.Content};
        }
    }
}
