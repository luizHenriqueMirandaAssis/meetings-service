using FluentValidation;
using Schedule.Meetings.Application.Models;

namespace Schedule.Meetings.API.V1.Validators
{
    public class ScheduleMeetingsValidator : AbstractValidator<ScheduleMeetingsModel>
    {

        public ScheduleMeetingsValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Date)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Start)
                .NotNull()
                .NotEmpty();

            RuleFor(e => e.End)
                .NotNull()
                .NotEmpty();

            RuleFor(e => e.UserId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(e => e.RoomId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
