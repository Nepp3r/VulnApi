namespace VulnAPI.Application.DTOs.Users.Profile
{
    public record ProfileDto
    {
        public string OwnerId;
        public string OwnerUniqueName;
        public string OwnerDisplayName;
        public string Description;
        public string Visibility;
        public int FollowerCount;
        public int FollowingCount;
        public string CreatedAt;
    }
}
