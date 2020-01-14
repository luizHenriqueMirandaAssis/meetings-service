using Schedule.Meetings.Domain.Entities;
using System.Collections.Generic;

namespace Schedule.Meetings.Application.Interfaces
{
    public interface IRoomsAppService
    {
        List<Rooms> GetAll();
    }
}
