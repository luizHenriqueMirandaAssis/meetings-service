using Schedule.Meetings.Domain.Interfaces.Repositories;
using Schedule.Meetings.Infrastructure.Data.Context;
using System.Linq;

namespace Schedule.Meetings.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScheduleMeetingsContext _context;

        public UnitOfWork(ScheduleMeetingsContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
