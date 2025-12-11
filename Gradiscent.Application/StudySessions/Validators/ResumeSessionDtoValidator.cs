using FluentValidation;
using Gradiscent.Application.StudySessions.DTOs;
namespace Gradiscent.Application.StudySessions.Validators
{
    public class ResumeSessionDtoValidator : AbstractValidator<ResumeSessionDto>
    {
        public ResumeSessionDtoValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}
