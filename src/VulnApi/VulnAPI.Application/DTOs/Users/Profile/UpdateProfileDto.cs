using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Application.DTOs.Users.Profile
{
    public record UpdateProfileDto
    {
        public string OwnerId;
        public string Description;
        public string Visibility;
    }
}
