using Gradiscent.Domain.Enums;
namespace Gradiscent.Application.StudyPlans.DTOs
{
    public class UpdateStudyPlanScheduleDto
    {
        public Weekday? DayOfWeek { get; set; }
        public int DurationMinutes { get; set; }
    }
}
