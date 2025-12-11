using Gradiscent.Domain.Enums;
namespace Gradiscent.Application.StudyPlans.DTOs
{
    public class CreateStudyPlanDto
    {
        public string Name { get; set; }
        public ReccurenceType ReccurenceType { get; set; }
    }
}
