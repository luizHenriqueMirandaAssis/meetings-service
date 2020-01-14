using System;

namespace Schedule.Meetings.Domain.Helpers
{
    public static class DateTimeHelper
    {
        public static TimeSpan ToTimeSpan(this DateTime date)
        {
            return TimeSpan.Parse(date.ToString("HH:mm:ss"));
        }

        public static TimeSpan AddMinutes(this TimeSpan time, int value)
        {
            return time.Add(new TimeSpan(0, value, 0));
        }

        public static TimeSpan NewTime(int hours, int minutes)
        {
            return new TimeSpan(hours, minutes, 0);
        }
    }
}
