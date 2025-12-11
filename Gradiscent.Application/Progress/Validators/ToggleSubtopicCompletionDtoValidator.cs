using FluentValidation;
using Gradiscent.Application.Progress.DTOs;
namespace Gradiscent.Application.Progress.Validators
{
    public class ToggleSubtopicCompletionDtoValidator : AbstractValidator<ToggleSubtopicCompletionDto>
    {
        public ToggleSubtopicCompletionDtoValidator()
        {
            RuleFor(x => x.IsCompleted)
                .NotNull();
        }
    }
}
