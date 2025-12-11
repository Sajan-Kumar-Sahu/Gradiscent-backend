using FluentValidation;
using Gradiscent.Application.Subjects.DTOs;

namespace Gradiscent.Application.Subjects.Validators
{
    public class UpdateSubjectDtoValidator : AbstractValidator<UpdateSubjectDto>
    {
        public UpdateSubjectDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .When(x => x.Description != null);

            RuleFor(x => x.OrderIndex)
                .GreaterThanOrEqualTo(0)
                .When(x => x.OrderIndex.HasValue);
        }
    }
}
