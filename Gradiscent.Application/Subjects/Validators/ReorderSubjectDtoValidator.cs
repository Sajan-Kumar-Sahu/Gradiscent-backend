using FluentValidation;
using Gradiscent.Application.Subjects.DTOs;

namespace Gradiscent.Application.Subjects.Validators
{
    public class ReorderSubjectDtoValidator : AbstractValidator<ReorderSubjectDto>
    {
        public ReorderSubjectDtoValidator()
        {
            RuleFor(x => x.NewOrderIndex)
                .GreaterThanOrEqualTo(0);
        }
    }
}
