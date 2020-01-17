using Schedule.Meetings.Domain.Entities;
using Schedule.Meetings.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Meetings.Domain.ValueObjects
{
    public static class Meeting
    {
        public static bool Available(List<ScheduleMeetings> scheduledMeetings, TimeSpan start, TimeSpan end)
        {
            if (scheduledMeetings == null || !scheduledMeetings.Any())
                return true;

            var meetingAvailable = GetAvailablePeriod(scheduledMeetings);

            return meetingAvailable.Any(x => start >= x.MeetingStart && end <= x.MeetingEnd);
        }

        public static bool MinimumTime(TimeSpan x, TimeSpan y)
        {
            var minimumTime = new TimeSpan(0, 5, 0);

            return (x - y) > minimumTime;
        }

        public static List<ScheduleMeetings> GetAvailablePeriod(List<ScheduleMeetings> scheduledMeetings)
        {
            scheduledMeetings = scheduledMeetings.OrderBy(x => x.MeetingStart).ToList();
            var meetingAvailable = new List<ScheduleMeetings>();
            var currentTime = DateTime.Now.ToTimeSpan();
            var lastHour = new TimeSpan(23, 59, 59);
            var previousMeetingEnd = TimeSpan.Zero;

            for (int i = 1; i <= scheduledMeetings.Count; i++)
            {
                var item = scheduledMeetings[i - 1];

                if (previousMeetingEnd == TimeSpan.Zero && currentTime < item.MeetingStart)
                    meetingAvailable.Add(ScheduleMeetings.Build(currentTime, item.MeetingStart.AddMinutes(-1)));

                if (previousMeetingEnd > TimeSpan.Zero && MinimumTime(item.MeetingStart, previousMeetingEnd))
                    meetingAvailable.Add(ScheduleMeetings.Build(previousMeetingEnd.AddMinutes(1), item.MeetingStart.AddMinutes(-1)));

                if (i == scheduledMeetings.Count && MinimumTime(lastHour, item.MeetingEnd))
                    meetingAvailable.Add(ScheduleMeetings.Build(item.MeetingEnd.AddMinutes(1), lastHour));

                previousMeetingEnd = item.MeetingEnd;
            }

            return meetingAvailable;
        }
    }
}
