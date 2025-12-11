using FluentValidation;
using Gradiscent.Application.Roadmaps.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.Roadmaps.Validators
{
    public class MergeToSubtopicDtoValidator : AbstractValidator<MergeToSubtopicDto>
    {
        public MergeToSubtopicDtoValidator()
        {
            RuleFor(x => x.SubtopicId).NotEmpty();
        }
    }
}
