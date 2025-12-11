namespace Gradiscent.Application.Dashboard.DTOs
{
    public class DashboardTimetableEntryDto
    {
        public Guid EntryId { get; set; }

        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Guid? TopicId { get; set; }
        public string? TopicName { get; set; }

        public int ScheduledMinutes { get; set; }
        public int StudiedMinutes { get; set; }

        public bool IsCompleted { get; set; }
    }
}
