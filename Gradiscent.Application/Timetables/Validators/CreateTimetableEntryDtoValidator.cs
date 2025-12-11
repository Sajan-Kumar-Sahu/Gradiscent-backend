using FluentValidation;
using Gradiscent.Application.Timetables.DTOs;
namespace Gradiscent.Application.Timetables.Validators
{
    public class CreateTimetableEntryDtoValidator : AbstractValidator<CreateTimetableEntryDto>
    {
        public CreateTimetableEntryDtoValidator()
        {
            RuleFor(x => x.SubjectId).NotEmpty();

            RuleFor(x => x.DayOfWeek)
                .IsInEnum();

            RuleFor(x => x.DurationMinutes)
                .GreaterThan(0)
                .LessThanOrEqualTo(1440); // max 24 hours
        }
    }
}
