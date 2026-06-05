using System;
using System.Collections.Generic;
using System.Linq;

namespace VulnAPI.Domain.Post
{
    public class Post
    {
        private readonly List<Post> _replies = new();
        private readonly List<PostLike> _likes = new();

        private Post() { }
        public int Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public int? ParentPostId { get; private set; }
        public string? Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Deleted { get; private set; }
        public IReadOnlyCollection<Post> Replies => _replies.AsReadOnly();
        public IReadOnlyCollection<PostLike> Likes => _likes.AsReadOnly();

        public bool IsTopLevel => ParentPostId == null;
        public bool IsComment => ParentPostId != null;
        public int ReplyCount => _replies.Count(r => !r.Deleted);
        public int LikeCount => _likes.Count;
        public static Post CreatePost(Guid authorId, string title, string content)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required for posts", nameof(title));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be empty", nameof(content));

            return new Post
            {
                AuthorId = authorId,
                ParentPostId = null,
                Title = title,
                Content = content,
                CreatedAt = DateTime.UtcNow,
                Deleted = false
            };
        }
        public static Post CreateComment(Guid authorId, int parentPostId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be empty", nameof(content));

            return new Post
            {
                AuthorId = authorId,
                ParentPostId = parentPostId,
                Title = null,
                Content = content,
                CreatedAt = DateTime.UtcNow,
                Deleted = false
            };
        }

        public Post AddReply(Guid authorId, string content)
        {
            if (Deleted)
                throw new InvalidOperationException("Cannot reply to deleted post");

            var reply = Post.CreateComment(authorId, Id, content);
            _replies.Add(reply);
            return reply;
        }

        public void Edit(string newContent, string newTitle = null)
        {
            if (Deleted)
                throw new InvalidOperationException("Cannot edit deleted post");

            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Content cannot be empty", nameof(newContent));

            Content = newContent;

            if (IsTopLevel && newTitle != null)
            {
                if (string.IsNullOrWhiteSpace(newTitle))
                    throw new ArgumentException("Title cannot be empty for posts", nameof(newTitle));

                Title = newTitle;
            }
        }

        public void Like(Guid userId)
        {
            if (Deleted)
                throw new InvalidOperationException("Cannot like deleted post");

            if (_likes.Any(l => l.UserId == userId))
                throw new InvalidOperationException("User already liked this post");

            var like = PostLike.Create(Id, userId);
            _likes.Add(like);
        }

        public void Unlike(Guid userId)
        {
            var like = _likes.FirstOrDefault(l => l.UserId == userId);
            if (like == null)
                throw new InvalidOperationException("User hasn't liked this post");

            _likes.Remove(like);
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
