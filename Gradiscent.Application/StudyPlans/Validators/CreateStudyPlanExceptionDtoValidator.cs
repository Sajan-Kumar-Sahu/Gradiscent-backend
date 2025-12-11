using FluentValidation;
using Gradiscent.Application.StudyPlans.DTOs;
namespace Gradiscent.Application.StudyPlans.Validators
{
    public class CreateStudyPlanExceptionDtoValidator : AbstractValidator<CreateStudyPlanExceptionDto>
    {
        public CreateStudyPlanExceptionDtoValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.Reason)
                .MaximumLength(200)
                .When(x => x.Reason != null);
        }
    }
}
