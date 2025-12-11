using FluentValidation;
using Gradiscent.Application.Roadmaps.DTOs;
namespace Gradiscent.Application.Roadmaps.Validators
{
    public class UpdateRoadmapItemStatusDtoValidator : AbstractValidator<UpdateRoadmapItemStatusDto>
    {
        public UpdateRoadmapItemStatusDtoValidator()
        {
            RuleFor(x => x.Status)
                .IsInEnum();
        }
    }
}
