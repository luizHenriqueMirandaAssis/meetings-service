using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Meetings.Domain.Entities;
using Schedule.Meetings.Domain.Helpers;

namespace Schedule.Meetings.Infrastructure.Data.Mappings
{
    public class UsersMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Username);
            builder.Property(x => x.Password);
        }
    }
}
