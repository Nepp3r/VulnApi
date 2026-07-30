using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Application.DTOs.Users
{
    public record UserBlockDto
    {
        public string Reason;
        public string BlockedAt;
        public string? Duration;
    }
}
