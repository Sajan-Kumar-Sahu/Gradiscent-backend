using FluentValidation;
using Gradiscent.Application.Roadmaps.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.Roadmaps.Validators
{
    public class MergeToSubjectDtoValidator : AbstractValidator<MergeToSubjectDto>
    {
        public MergeToSubjectDtoValidator()
        {
            RuleFor(x => x.SubjectId).NotEmpty();
        }
    }
}
