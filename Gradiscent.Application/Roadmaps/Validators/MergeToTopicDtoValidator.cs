using FluentValidation;
using Gradiscent.Application.Roadmaps.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.Roadmaps.Validators
{
    public class MergeToTopicDtoValidator : AbstractValidator<MergeToTopicDto>
    {
        public MergeToTopicDtoValidator()
        {
            RuleFor(x => x.TopicId).NotEmpty();
        }
    }
}
