using FluentValidation;
using Gradiscent.Application.StudySessions.DTOs;
namespace Gradiscent.Application.StudySessions.Validators
{
    public class PauseSessionDtoValidator : AbstractValidator<PauseSessionDto>
    {
        public PauseSessionDtoValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}
