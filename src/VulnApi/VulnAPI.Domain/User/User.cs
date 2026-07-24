using System;
using System.Collections.Generic;
using System.Linq;
using VulnAPI.Domain.User.ValueObjects;
using VulnAPI.Domain.Watchlist;

namespace VulnAPI.Domain.User
{
    public class User
    {
        public Guid Id { get; private set; }
        public DisplayName DisplayName { get; private set; }
        public UniqueName UniqueName { get; private set; }
        public Role Role { get; private set; }
        private readonly List<Follow> _followers = new();
        private readonly List<Follow> _following = new();
        private readonly List<WatchlistItem> _watchlist = new();

        public IReadOnlyCollection<Follow> Followers => _followers.AsReadOnly();
        public IReadOnlyCollection<Follow> Following => _following.AsReadOnly();
        public IReadOnlyCollection<WatchlistItem> Watchlist => _watchlist.AsReadOnly();
        public Email Email { get; private set; }
        public UserBlock? ActiveBlock { get; private set; }
        public bool Deleted { get; private set; }
        public bool Verified { get; private set; }
        private User() { }
        public static User Create(string displayName, string uniqueName, Role role, string email)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                DisplayName = DisplayName.Create(displayName),
                UniqueName = UniqueName.Create(uniqueName),
                Role = role,
                Email = Email.Create(email),
                ActiveBlock = null,
                Deleted = false,
                Verified = false
            };
        }
        public Follow Follow(User userToFollow)
        {
            if (userToFollow.Id == Id)
                throw new InvalidOperationException("Cannot follow yourself");

            if (_following.Any(f => f.FollowingId == userToFollow.Id))
                throw new InvalidOperationException("Already following this user");

            var follow = Domain.User.Follow.Create(Id, userToFollow.Id);
            _following.Add(follow);
            return follow;
        }
        public void AddFollower(Follow follow)
        {
            if (follow.FollowingId != Id)
                throw new InvalidOperationException("Follow record does not match this user");

            if (_followers.Any(f => f.FollowerId == follow.FollowerId))
                return;

            _followers.Add(follow);
        }

        public void Unfollow(Guid userId)
        {
            var follow = _following.FirstOrDefault(f => f.FollowingId == userId);
            if (follow == null)
                throw new InvalidOperationException("Not following this user");

            _following.Remove(follow);
        }
        public void RemoveFollower(Guid followerId)
        {
            var follow = _followers.FirstOrDefault(f => f.FollowerId == followerId);
            if (follow != null)
                _followers.Remove(follow);
        }
        public UserBlock Block(string? reason, TimeSpan? duration)
        {
            if (Deleted)
                throw new InvalidOperationException("Cannot block deleted user");
            if (Role == Role.Admin)
                throw new InvalidOperationException("Cannot block administrator level user");

            ActiveBlock = UserBlock.Create(reason, duration);
            return ActiveBlock;
        }
        public UserBlock BlockPermanently(string? reason)
        {
            if (Deleted)
                throw new InvalidOperationException("Cannot block deleted user");
            if (Role == Role.Admin)
                throw new InvalidOperationException("Cannot block administrator level user");

            ActiveBlock = UserBlock.Create(reason, null);
            return ActiveBlock;
        }

        public void Unblock()
        {
            if(ActiveBlock == null)
                throw new InvalidOperationException("User is already unblocked");

            ActiveBlock = null;
        }
    }
}
