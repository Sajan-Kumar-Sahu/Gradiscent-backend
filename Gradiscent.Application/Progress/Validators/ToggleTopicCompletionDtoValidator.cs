using FluentValidation;
using Gradiscent.Application.Progress.DTOs;
namespace Gradiscent.Application.Progress.Validators
{
    public class ToggleTopicCompletionDtoValidator : AbstractValidator<ToggleTopicCompletionDto>
    {
        public ToggleTopicCompletionDtoValidator()
        {
            RuleFor(x => x.IsCompleted)
                .NotNull();
        }
    }
}
