namespace Gradiscent.Domain.Entities
{
    public class StudyPlanException
    {
        public Guid Id { get; set; }
        public Guid StudyPlanId { get; set; }

        public DateTime Date { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsAdded { get; set; }

        public string? Reason { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
