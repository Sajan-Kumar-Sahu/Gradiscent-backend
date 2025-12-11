namespace Gradiscent.Application.StudyPlans.DTOs
{
    public class StudyPlanResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReccurenceType { get; set; }

        public List<StudyPlanScheduleResponseDto> Schedule { get; set; } = new();
        public List<StudyPlanExceptionResponseDto> Exceptions { get; set; } = new();
    }
}
