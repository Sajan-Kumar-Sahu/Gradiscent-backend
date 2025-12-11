namespace Gradiscent.Application.Dashboard.DTOs
{
    public class DashboardSessionDto
    {
        public Guid SessionId { get; set; }

        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Guid? TopicId { get; set; }
        public string? TopicName { get; set; }

        public DateTime StartedAt { get; set; }
        public int MinutesElapsed { get; set; }
    }
}
