using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Meetings.Domain.Entities;

namespace Schedule.Meetings.Infrastructure.Data.Mappings
{
    public class RoomsMap : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {
            builder.HasKey(e => e.RoomId);
            builder.Property(e => e.Name);
            builder.Property(e => e.Description);
        }
    }
}
