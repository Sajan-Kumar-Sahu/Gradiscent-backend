using FluentValidation;
using Gradiscent.Application.StudySessions.DTOs;
namespace Gradiscent.Application.StudySessions.Validators
{
    public class EndSessionDtoValidator : AbstractValidator<EndSessionDto>
    {
        public EndSessionDtoValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}
