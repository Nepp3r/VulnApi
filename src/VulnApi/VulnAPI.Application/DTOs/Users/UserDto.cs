namespace VulnAPI.Application.DTOs.Users
{
    public record UserDto
    {
        public string Name;
        public string UniqueName;
        public int followersCount;
        public int followingCount;
    }
}
