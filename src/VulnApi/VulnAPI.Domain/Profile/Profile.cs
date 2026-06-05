using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Domain.Profile
{
    public class Profile
    {
        private Profile() { }

        public static Profile Create(Guid ownerId, string description, Visibility visibility)
        {
            return new Profile
            {
                OwnerId = ownerId,
                Description = description,
                Visibility = visibility,
                CreatedAt = DateTime.UtcNow
            };
        }
        public Guid OwnerId { get; private set; }
        public string Description { get; private set; }
        public Visibility Visibility { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void ChangeVisibility(Visibility visibility)
        {
            Visibility = visibility;
        }
    }
}
