using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Meetings.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false, maxLength: 60),
                    Description = table.Column<string>(nullable: false, maxLength: 200)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false, maxLength: 100),
                    Password = table.Column<string>(nullable: false, maxLength: 32)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleMeetings",
                columns: table => new
                {
                    ScheduleMeetingId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false, maxLength: 100),
                    UserId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    MeetingStart = table.Column<TimeSpan>(nullable: false),
                    MeetingEnd = table.Column<TimeSpan>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleMeetings", x => x.ScheduleMeetingId);
                    table.ForeignKey(
                         name: "FK_ScheduleMeetings_Users_UserId",
                         column: x => x.UserId,
                         principalTable: "Users",
                         principalColumn: "UserId",
                         onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                         name: "FK_ScheduleMeetings_Rooms_RoomId",
                         column: x => x.RoomId,
                         principalTable: "Rooms",
                         principalColumn: "RoomId",
                         onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "ScheduleMeetings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
