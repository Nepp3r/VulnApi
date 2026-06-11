using System;
using System.Collections.Generic;
using System.Text;
using VulnAPI.Domain.User.ValueObjects;

namespace VulnAPI.Domain.Admin
{
    public class Report
    {
        private Report() { }
        public int Id { get; set; }
        public Guid Author { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }
        public ReportStatus Status { get; private set; }
        public static Report Create(Guid author, string title, string text)
        {
            if (title.Length > 50 || String.IsNullOrEmpty(title))
                throw new ArgumentException("Invalid report title", nameof(title));
            if (text.Length > 1000 || String.IsNullOrEmpty(text))
                throw new ArgumentException("Invalid report text", nameof(text));
            if (author == null)
                throw new ArgumentException("Author Id is null", nameof(author));
            return new Report
            {
                Author = author,
                Title = title,
                Text = text,
                CreatedOn = DateTime.Now,
                Status = ReportStatus.New
            };
        }
        public void ChangeStatus(ReportStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
