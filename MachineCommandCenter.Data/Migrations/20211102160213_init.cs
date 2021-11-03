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
                    { new Guid("bb67207e-af12-4a46-a419-e2e9b9805ed6"), 1, "Telehandler", new DateTime(2021, 11, 2, 17, 2, 12, 944, DateTimeKind.Local).AddTicks(8118) },
                    { new Guid("2535cc65-41e2-4eb7-a505-63ad71c6e73b"), 0, "Single Man Lift", new DateTime(2021, 11, 2, 17, 2, 12, 949, DateTimeKind.Local).AddTicks(2329) },
                    { new Guid("aad1eb46-64f1-4c7f-9b7d-cbdc18e24b2f"), 1, "Wheel Tractor-Scraper", new DateTime(2021, 11, 2, 17, 2, 12, 949, DateTimeKind.Local).AddTicks(2554) },
                    { new Guid("f88bd76f-26d5-45ac-88a6-80d2765ce39c"), 0, "Skid Steer Loader", new DateTime(2021, 11, 2, 17, 2, 12, 949, DateTimeKind.Local).AddTicks(2611) },
                    { new Guid("e6d0152b-d055-4dc8-8980-ccc38a3337b3"), 0, "Scissor Lift", new DateTime(2021, 11, 2, 17, 2, 12, 949, DateTimeKind.Local).AddTicks(2659) },
                    { new Guid("bd5ba167-44be-46f7-b884-573d12240605"), 1, "Forklift", new DateTime(2021, 11, 2, 17, 2, 12, 949, DateTimeKind.Local).AddTicks(2720) },
                    { new Guid("34fd4f7e-9f3c-4e8a-848a-2ca4b6b2aaf6"), 1, "Bulldozer", new DateTime(2021, 11, 2, 17, 2, 12, 949, DateTimeKind.Local).AddTicks(2781) },
                    { new Guid("b8b8fa7d-adfe-4dd7-9846-7a313a1ba4ca"), 0, "Backhoe Loader", new DateTime(2021, 11, 2, 17, 2, 12, 949, DateTimeKind.Local).AddTicks(2832) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
