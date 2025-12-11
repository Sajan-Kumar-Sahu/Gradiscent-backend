using Gradiscent.Domain.Enums;
namespace Gradiscent.Application.StudyPlans.DTOs
{
    public class UpdateStudyPlanDto
    {
        public string Name { get; set; }
        public ReccurenceType ReccurenceType { get; set; }
    }
}
