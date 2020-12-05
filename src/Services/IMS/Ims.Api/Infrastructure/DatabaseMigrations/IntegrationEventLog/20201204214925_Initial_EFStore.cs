using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ax3.IMS.Infrastructure.EventBus.EFEventStore.Migrations
{
    public partial class Initial_EFStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "integration_event_log",
                columns: table => new
                {
                    event_id = table.Column<Guid>(nullable: false),
                    event_type_name = table.Column<string>(nullable: false),
                    state = table.Column<int>(nullable: false),
                    times_sent = table.Column<int>(nullable: false),
                    creation_time = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(nullable: false),
                    transaction_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_integration_event_log", x => x.event_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "integration_event_log");
        }
    }
}
