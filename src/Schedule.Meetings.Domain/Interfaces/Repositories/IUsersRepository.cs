using Schedule.Meetings.Domain.Entities;

namespace Schedule.Meetings.Domain.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<Users>
    {
        bool Exists(int id);
    }
}
