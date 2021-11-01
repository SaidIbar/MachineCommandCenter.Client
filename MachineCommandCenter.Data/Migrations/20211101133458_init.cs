using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MachineCommandCenter.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineStatus = table.Column<int>(type: "int", nullable: false),
                    SentDataDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "MachineId", "MachineStatus", "Name", "SentDataDateTime" },
                values: new object[,]
                {
                    { new Guid("d3ef0437-c6bf-4654-bfea-c6883d7e11d6"), 1, "Telehandler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009) },
                    { new Guid("a480ba91-7618-4d95-92e1-751a08560bf3"), 0, "Single Man Lift", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009) },
                    { new Guid("9f552147-0b76-4666-82a8-79008e09e1ba"), 1, "Wheel Tractor-Scraper", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009) },
                    { new Guid("6500ff82-31fd-405d-a06b-41bf25070d68"), 0, "Skid Steer Loader", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009) },
                    { new Guid("2ad53da7-d8ca-4b89-9464-1904e0e461de"), 0, "Scissor Lift", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009) },
                    { new Guid("08c04174-171e-4c19-a615-4053b688464c"), 1, "Forklift", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1981) },
                    { new Guid("a570092a-6e93-4236-8bc9-631da397abb4"), 1, "Bulldozer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { new Guid("8fe7dba0-354a-40f9-9fd4-4f4079a814fc"), 0, "Backhoe Loader", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
