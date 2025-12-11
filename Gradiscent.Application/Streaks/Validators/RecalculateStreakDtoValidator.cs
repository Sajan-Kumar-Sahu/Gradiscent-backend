using FluentValidation;
using Gradiscent.Application.Streaks.DTOs;
namespace Gradiscent.Application.Streaks.Validators
{
    public class RecalculateStreakDtoValidator : AbstractValidator<RecalculateStreakDto>
    {
        public RecalculateStreakDtoValidator()
        {
            // No real rules needed yet.
        }
    }
}
