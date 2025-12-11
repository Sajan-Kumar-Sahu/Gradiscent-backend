using FluentValidation;
using Gradiscent.Application.Roadmaps.DTOs;

namespace Gradiscent.Application.Roadmaps.Validators
{
    public class GenerateRoadmapRequestDtoValidator : AbstractValidator<GenerateRoadmapRequestDto>
    {
        public GenerateRoadmapRequestDtoValidator()
        {
            RuleFor(x => x.Goal)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .When(x => x.Description != null);

            RuleFor(x => x.TargetDurationWeeks)
                .GreaterThan(0)
                .When(x => x.TargetDurationWeeks.HasValue);
        }
    }
}
