using FluentValidation;
using Gradiscent.Application.Authentication.DTOs;

namespace Gradiscent.Application.Authentication.Validators
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenDto>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty();
        }
    }
}
