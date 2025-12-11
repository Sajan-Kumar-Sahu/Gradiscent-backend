using FluentValidation;
using Gradiscent.Application.Subjects.DTOs;

namespace Gradiscent.Application.Subjects.Validators
{
    public class ReorderTopicDtoValidator : AbstractValidator<ReorderTopicDto>
    {
        public ReorderTopicDtoValidator()
        {
            RuleFor(x => x.NewOrderIndex)
               .GreaterThanOrEqualTo(0);
        }
    }
}
