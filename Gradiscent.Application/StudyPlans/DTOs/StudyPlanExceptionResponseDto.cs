namespace Gradiscent.Application.StudyPlans.DTOs
{
    public class StudyPlanExceptionResponseDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
    }
}
