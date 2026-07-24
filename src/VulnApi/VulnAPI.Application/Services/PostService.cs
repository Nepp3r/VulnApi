using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VulnAPI.Application.DTOs.Posts;
using VulnAPI.Application.Mappings;
using VulnAPI.Application.Interfaces;
using VulnAPI.Domain.Post;
using System;

namespace VulnAPI.Application.Services
{
    public class PostService
    {
        private readonly IVulnApiDbContext _dbContext;
        public PostService(IVulnApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PostDto> GetPostByIdAsync(int postId, CancellationToken ct = default)
        {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId, ct);
            if (post is null)
                throw new KeyNotFoundException("No post with such Id was found");
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == post.AuthorId, ct);
            if (user is null)
                throw new KeyNotFoundException("No user with such Id was found");
            PostDto data;
            if (user.Deleted)
                data = PostMappings.ToDto(post, "", "Deleted User");
            else
                data = PostMappings.ToDto(post, user.DisplayName.Value, user.UniqueName.Value);
            return data;
        }
        public async Task<List<PostDto>> GetPostCommentsAsync(int parentPostId, CancellationToken ct = default)
        {
            var posts = await _dbContext.Posts.Join(_dbContext.Users,
                                                post => post.AuthorId,
                                                user => user.Id,
                                                (post, user) =>
                                                new {Post = post, UserDisplayName = user.DisplayName, UserUniqueName = user.UniqueName, UserDeleted = user.Deleted })
                                        .Select(p => PostMappings.ToDto(p.Post, p.UserDeleted ? "" : p.UserUniqueName.Value, p.UserDeleted ? "Deleted User" : p.UserDisplayName.Value))
                                        .ToListAsync(ct);
            return posts;
        }
        public async Task CreatePostAsync(CreatePostDto postData, CancellationToken ct = default)
        {
            Post post;
            if (postData.ParentPostId == null)
                post = Post.CreatePost(Guid.Parse(postData.AuthorId), postData.Title!, postData.Content);
            else
                post = Post.CreateComment(Guid.Parse(postData.AuthorId), postData.ParentPostId.Value, postData.Content);
            await _dbContext.Posts.AddAsync(post, ct);
            await _dbContext.SaveChangesAsync(ct);
        }
        public async Task UpdatePostAsync(UpdatePostDto postData)
        {
            Post post = _dbContext.Posts.FirstOrDefault(p => p.Id == postData.PostId);
            if(post == null)
                throw new KeyNotFoundException("No post with such Id was found");
            if ((post.IsComment && !String.IsNullOrEmpty(postData.Title)) || (post.IsTopLevel && String.IsNullOrEmpty(postData.Title)))
                throw new FormatException("Given post data format is ivalid");
            post.Edit(postData.Content, postData.Title);
        }
        public async Task DeletePostAsync(uint postId, CancellationToken ct = default)
        {
            Post post = _dbContext.Posts.FirstOrDefault(p => p.Id == postId);
            if(post == null)
                throw new KeyNotFoundException("No post with such Id was found");
            post.Delete();
            await _dbContext.SaveChangesAsync(ct);
        }
    }
}
