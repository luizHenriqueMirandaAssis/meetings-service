using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.Meetings.Domain.Entities;
using Schedule.Meetings.Domain.Interfaces.Repositories;
using Schedule.Meetings.Infrastructure.Data.Context;

namespace Schedule.Meetings.Infrastructure.Data.Repositories
{
    public class ScheduleMeetingsRepository : Repository<ScheduleMeetings>, IScheduleMeetingsRepository
    {
        public ScheduleMeetingsRepository(ScheduleMeetingsContext context) : base(context) { }

        public List<ScheduleMeetings> GetByDate(DateTime meetingDate, int roomId)
        {
            return DbSet.Where(x => x.RoomId.Equals(roomId) && x.MeetingDate.Equals(meetingDate)).ToList();
        }
    }
}
