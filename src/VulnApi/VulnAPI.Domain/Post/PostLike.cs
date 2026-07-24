using System;

namespace VulnAPI.Domain.Post
{
    public class PostLike
    {
        private PostLike() { }

        public static PostLike Create(uint postId, Guid userId)
        {
            return new PostLike
            {
                PostId = postId,
                UserId = userId,
                LikedAt = DateTime.UtcNow
            };
        }
        public uint PostId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime LikedAt { get; private set; }
    }
}