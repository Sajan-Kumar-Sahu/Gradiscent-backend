using FluentValidation;
using Gradiscent.Application.StudySessions.DTOs;
namespace Gradiscent.Application.StudySessions.Validators
{
    public class StartSessionDtoValidator : AbstractValidator<StartSessionDto>
    {
        public StartSessionDtoValidator()
        {
            RuleFor(x => x.SubjectId)
                .NotEmpty();
        }
    }
}
