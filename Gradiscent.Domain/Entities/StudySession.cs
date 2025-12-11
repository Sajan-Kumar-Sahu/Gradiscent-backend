namespace Gradiscent.Domain.Entities
{
    public class StudySession
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public Guid SubjectId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int TotalSeconds { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
