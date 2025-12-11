namespace Gradiscent.Domain.Entities
{
    public class StudyPlan
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid SubjectId { get; set; }

        public int RequiredMinutes { get; set; }

        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
