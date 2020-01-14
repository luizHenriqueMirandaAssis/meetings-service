using Schedule.Meetings.Domain.Entities;
using Schedule.Meetings.Domain.Interfaces.Repositories;
using Schedule.Meetings.Infrastructure.Data.Context;
using System.Linq;

namespace Schedule.Meetings.Infrastructure.Data.Repositories
{
    public class RoomsRepository : Repository<Rooms>, IRoomsRepository
    {
        public RoomsRepository(ScheduleMeetingsContext context) : base(context) { }

        public bool Exists(int id)
        {
            return DbSet.Any(x => x.RoomId.Equals(id));
        }
    }
}
