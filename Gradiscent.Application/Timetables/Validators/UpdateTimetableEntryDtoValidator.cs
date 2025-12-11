using FluentValidation;
using Gradiscent.Application.Timetables.DTOs;
namespace Gradiscent.Application.Timetables.Validators
{
    public class UpdateTimetableEntryDtoValidator : AbstractValidator<UpdateTimetableEntryDto>
    {
        public UpdateTimetableEntryDtoValidator()
        {
            RuleFor(x => x.SubjectId).NotEmpty();

            RuleFor(x => x.DayOfWeek)
                .IsInEnum();

            RuleFor(x => x.DurationMinutes)
                .GreaterThan(0);
        }
    }
}
