namespace Gradiscent.Application.Dashboard.DTOs
{
    public class DashboardSubjectSummaryDto
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int ProgressPercentage { get; set; }
        public int MinutesStudiedToday { get; set; }
        public int WeeklyMinutes { get; set; }
    }
}
