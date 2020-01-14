using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Meetings.Infrastructure.Data.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "1° Andar", "Sala de reunião 1" },
                    { 2, "2° andar", "Sala de reunião 2" },
                    { 3, "3° andar", "Sala de reunião 3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "e10adc3949ba59abbe56e057f20f883e", "LuizHenrique" },
                    { 2, "e10adc3949ba59abbe56e057f20f883e", "Miranda" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
