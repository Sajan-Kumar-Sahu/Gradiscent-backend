using FluentValidation;
using Gradiscent.Application.Subjects.DTOs;
namespace Gradiscent.Application.Subjects.Validators
{
    public class ReorderSubtopicDtoValidator : AbstractValidator<ReorderSubtopicDto>
    {
        public ReorderSubtopicDtoValidator()
        {
            RuleFor(x => x.NewOrderIndex)
                .GreaterThanOrEqualTo(0);
        }
    }
}
