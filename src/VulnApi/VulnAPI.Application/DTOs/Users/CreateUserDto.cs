using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Application.DTOs.Users
{
    public record CreateUserDto
    {
        public string DisplayName;
        public string UniqueName;
        public string Email;
        public string Role;
    }
}
