using System;

namespace Schedule.Meetings.Application.Models
{
    public class ScheduleMeetingsModel
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
