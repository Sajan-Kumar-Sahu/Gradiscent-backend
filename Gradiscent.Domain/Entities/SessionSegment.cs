namespace Gradiscent.Domain.Entities
{
    public class SessionSegment
    {
        public Guid Id { get; set; }
        public Guid StudySessionId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int DurationSeconds { get; set; }
    }
}
