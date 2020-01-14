using Microsoft.EntityFrameworkCore;
using Schedule.Meetings.Domain.Entities;
using Schedule.Meetings.Infrastructure.Data.Mappings;

namespace Schedule.Meetings.Infrastructure.Data.Context
{
    public class ScheduleMeetingsContext : DbContext
    {
        public ScheduleMeetingsContext(DbContextOptions<ScheduleMeetingsContext> options) : base(options) { }

        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ScheduleMeetings> ScheduleMeetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomsMap());
            modelBuilder.ApplyConfiguration(new ScheduleMeetingsMap());
            modelBuilder.ApplyConfiguration(new UsersMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
