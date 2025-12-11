using FluentValidation;
using Gradiscent.Application.Roadmaps.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.Roadmaps.Validators
{
    public class ReorderRoadmapItemDtoValidator : AbstractValidator<ReorderRoadmapItemDto>
    {
        public ReorderRoadmapItemDtoValidator()
        {
            RuleFor(x => x.NewOrderIndex)
                .GreaterThanOrEqualTo(0);
        }
    }
}
