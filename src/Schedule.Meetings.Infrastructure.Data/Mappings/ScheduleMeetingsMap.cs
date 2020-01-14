using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Meetings.Domain.Entities;

namespace Schedule.Meetings.Infrastructure.Data.Mappings
{
    public class ScheduleMeetingsMap : IEntityTypeConfiguration<ScheduleMeetings>
    {
        public void Configure(EntityTypeBuilder<ScheduleMeetings> builder)
        {
            builder.HasKey(e => e.ScheduleMeetingId);
            builder.Property(e => e.Title);
            builder.Property(e => e.RoomId);
            builder.Property(e => e.UserId);
            builder.Property(e => e.MeetingDate);
            builder.Property(e => e.MeetingStart);
            builder.Property(e => e.MeetingEnd);
            builder.Property(e => e.CreatedDate);
        }
    }
}
