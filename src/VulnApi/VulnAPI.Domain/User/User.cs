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
        public string Name { get; private set; }
        public UniqueName UniqueName { get; private set; }
        public Role Role { get; private set; }
        private readonly List<Follow> _followers = new();
        private readonly List<Follow> _following = new();

        public IReadOnlyCollection<Follow> Followers => _followers.AsReadOnly();
        public IReadOnlyCollection<Follow> Following => _following.AsReadOnly();
        public Email Email { get; private set; }
        public ICollection<WatchlistItem> Watchlist { get; private set; }
        public bool Blocked { get; private set; }
        public bool Deleted { get; private set; }
        public bool Verified { get; private set; }
        public bool CanAccess => Verified && !Blocked && !Deleted;
        private User() { }
        public static User Create(string name, string uniqueName, Role role, string email)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                UniqueName = UniqueName.Create(uniqueName),
                Role = role,
                Email = Email.Create(email),
                Watchlist = new List<WatchlistItem>(),
                Blocked = false,
                Deleted = false,
                Verified = false
            };
        }
        public void Follow(User userToFollow)
        {
            if (userToFollow.Id == Id)
                throw new InvalidOperationException("Cannot follow yourself");

            if (_following.Any(f => f.FollowingId == userToFollow.Id))
                throw new InvalidOperationException("Already following this user");

            var follow = Domain.User.Follow.Create(Id, userToFollow.Id);
            _following.Add(follow);
            userToFollow._followers.Add(follow);
        }

        public void Unfollow(Guid userId)
        {
            var follow = _following.FirstOrDefault(f => f.FollowingId == userId);
            if (follow == null)
                throw new InvalidOperationException("Not following this user");

            _following.Remove(follow);
        }
        public void Block(string reason)
        {
            if (Deleted)
                throw new InvalidOperationException("Cannot block deleted user");

            Blocked = true;
        }

        public void Unblock()
        {
            if (!Blocked)
                throw new InvalidOperationException("User is not blocked");

            Blocked = false;
        }
    }
}
