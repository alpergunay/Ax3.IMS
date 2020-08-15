using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Identity.Api.Data.Migrations.ApplicationDb
{
    public partial class UserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    LogoffTime = table.Column<DateTime>(nullable: false),
                    ClientIp = table.Column<string>(nullable: true),
                    ApplicationName = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    LastlastTradingTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");
        }
    }
}