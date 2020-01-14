using FluentValidation;
using Schedule.Meetings.Application.Models;
using Schedule.Meetings.Domain.Helpers;
using System;

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
                .NotEmpty()
                .GreaterThan(DateTime.Today.AddDays(-1));

            RuleFor(x => x.Start)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.Now.ToTimeSpan());

            RuleFor(e => e.End)
                .NotNull()
                .NotEmpty()
                .GreaterThan(y => y.Start);

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
