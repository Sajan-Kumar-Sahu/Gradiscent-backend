using FluentValidation;
using Gradiscent.Application.Authentication.DTOs;

namespace Gradiscent.Application.Authentication.Validators
{
    public class UpdateUserProfileDtoValidator : AbstractValidator<UpdateUserProfileDto>
    {
        public UpdateUserProfileDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
