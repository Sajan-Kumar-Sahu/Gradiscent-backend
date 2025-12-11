using FluentValidation;
using Gradiscent.Application.StudyPlans.DTOs;
namespace Gradiscent.Application.StudyPlans.Validators
{
    public class UpdateStudyPlanScheduleDtoValidator : AbstractValidator<UpdateStudyPlanScheduleDto>
    {
        public UpdateStudyPlanScheduleDtoValidator()
        {
            RuleFor(x => x.DurationMinutes).GreaterThan(0);
            RuleFor(x => x.DayOfWeek).IsInEnum().When(x => x.DayOfWeek.HasValue);
        }
    }
}
