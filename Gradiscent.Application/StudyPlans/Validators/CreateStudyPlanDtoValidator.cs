using FluentValidation;
using Gradiscent.Application.StudyPlans.DTOs;
namespace Gradiscent.Application.StudyPlans.Validators
{
    public class CreateStudyPlanDtoValidator : AbstractValidator<CreateStudyPlanDto>
    {
        public CreateStudyPlanDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.ReccurenceType)
                .IsInEnum();
        }
    }
}
