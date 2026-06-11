namespace VulnAPI.Application.DTOs.Users
{
    public record UserDto
    {
        string Name;
        string UniqueName;
        int followersCount;
        int followingCount;
    }
}
