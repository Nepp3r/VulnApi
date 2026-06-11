using System;

namespace VulnAPI.Domain.User
{
    public class Follow
    {
        private Follow() { }

        public static Follow Create(Guid followerId, Guid followingId)
        {
            return new Follow
            {
                FollowerId = followerId,
                FollowingId = followingId,
                FollowedAt = DateTime.UtcNow
            };
        }
        public Guid FollowerId { get; private set; }
        public Guid FollowingId { get; private set; }
        public DateTime FollowedAt { get; private set; }
    }
}
