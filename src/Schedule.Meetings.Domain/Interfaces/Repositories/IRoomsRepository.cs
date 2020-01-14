using Schedule.Meetings.Domain.Entities;

namespace Schedule.Meetings.Domain.Interfaces.Repositories
{
    public interface IRoomsRepository : IRepository<Rooms>
    {
        bool Exists(int id);
    }
}