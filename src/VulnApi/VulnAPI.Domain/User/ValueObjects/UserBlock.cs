using System;

namespace VulnAPI.Domain.User.ValueObjects
{
    public record UserBlock
    {
        private UserBlock() { }
        public string Reason { get; private set; }
        public DateTime BlockedAt { get; private set; }
        public TimeSpan? Duration { get; private set; }
        public bool IsActive => Duration == null || BlockedAt + Duration > DateTime.UtcNow;
        public bool IsPermanent => Duration == null;
        public TimeSpan? TimeRemaining => Duration.HasValue
            ? BlockedAt + Duration - DateTime.UtcNow
            : null;
        public static UserBlock Create(string? reason, TimeSpan? duration)
        {
            return new UserBlock
            {
                Reason = reason,
                BlockedAt = DateTime.UtcNow,
                Duration = duration
            };
        }
    }
}
