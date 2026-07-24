using VulnAPI.Application.DTOs.Admin;
using VulnAPI.Domain.Admin;

namespace VulnAPI.Application.Mappings
{
    public static class AdminMappings
    {
        public static ReportDto ToDTO(Report report)
        {
            return new ReportDto
            {
                AuthorId = report.Author,
                Title = report.Title,
                Text = report.Text,
                CreatedAt = report.CreatedAt,
                ClosedAt = report.ClosedAt,
                Status = report.Status.ToString()
            };
        }
    }
}
