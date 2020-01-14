using System;

namespace Schedule.Meetings.Domain.Entities
{
    public class ScheduleMeetings
    {
        public int ScheduleMeetingId { get; set; }
        public string Title { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime MeetingDate { get; set; }
        public TimeSpan MeetingStart { get; set; }
        public TimeSpan MeetingEnd { get; set; }
        public DateTime CreatedDate { get; set; }

        public static ScheduleMeetings New()
        {
            return new ScheduleMeetings()
            {
                CreatedDate = DateTime.Now
            };
        }

        public static ScheduleMeetings Build(TimeSpan meetingStart, TimeSpan meetingEnd)
        {
            return new ScheduleMeetings()
            {
                MeetingStart = meetingStart,
                MeetingEnd = meetingEnd
            };
        }
    }
}