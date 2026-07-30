namespace VulnAPI.Application.DTOs.Users
{
    public record UserDto
    {
        public string DisplayName;
        public string UniqueName;
        public string Role;
        public string Email;
        public bool Blocked;
        public UserBlockDto? Block;
        public bool Deleted;
        public bool Verified;
    }
}
