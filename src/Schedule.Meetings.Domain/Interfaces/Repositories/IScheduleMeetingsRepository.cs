using Schedule.Meetings.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Schedule.Meetings.Domain.Interfaces.Repositories
{
    public interface IScheduleMeetingsRepository : IRepository<ScheduleMeetings>
    {
        List<ScheduleMeetings> GetByDate(DateTime meetingDate, int roomId);
    }
}
