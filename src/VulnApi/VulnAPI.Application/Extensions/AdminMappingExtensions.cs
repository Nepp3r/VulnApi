using VulnAPI.Application.DTOs.Admin;
using VulnAPI.Domain.Admin;

namespace VulnAPI.Application.Extensions
{
    public static class AdminMappingExtensions
    {
        public static ReportDto ToDTO(this Report report)
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
