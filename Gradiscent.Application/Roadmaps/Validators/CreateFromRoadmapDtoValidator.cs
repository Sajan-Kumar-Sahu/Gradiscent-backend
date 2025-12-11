using FluentValidation;
using Gradiscent.Application.Roadmaps.DTOs;
namespace Gradiscent.Application.Roadmaps.Validators
{
    public class CreateFromRoadmapDtoValidator : AbstractValidator<CreateFromRoadmapDto>
    {
        public CreateFromRoadmapDtoValidator()
        {
            RuleFor(x => x.RoadmapId).NotEmpty();

            RuleFor(x => x.ParentEntityId)
                .NotEmpty()
                .When(x => x.ParentEntityId.HasValue);
        }
    }
}
