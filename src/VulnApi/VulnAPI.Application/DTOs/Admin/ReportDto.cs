using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Application.DTOs.Admin
{
    public record ReportDto
    {
        public Guid AuthorId;
        public string Title;
        public string Text;
        public DateTime CreatedAt;
        public DateTime? ClosedAt;
        public string Status;
    }
}
