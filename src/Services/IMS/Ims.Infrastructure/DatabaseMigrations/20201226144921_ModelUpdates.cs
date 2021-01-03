using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ims.Infrastructure.DatabaseMigrations
{
    public partial class ModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "country_id",
                schema: "ims",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "symbol",
                schema: "ims",
                table: "investment_tools",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: true),
                    modifier = table.Column<string>(nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    investment_tool_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.id);
                    table.ForeignKey(
                        name: "fk_country_investment_tools_investment_tool_id",
                        column: x => x.investment_tool_id,
                        principalSchema: "ims",
                        principalTable: "investment_tools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_country_id",
                schema: "ims",
                table: "users",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_country_investment_tool_id",
                table: "country",
                column: "investment_tool_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_country_country_id",
                schema: "ims",
                table: "users",
                column: "country_id",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_country_country_id",
                schema: "ims",
                table: "users");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropIndex(
                name: "ix_users_country_id",
                schema: "ims",
                table: "users");

            migrationBuilder.DropColumn(
                name: "country_id",
                schema: "ims",
                table: "users");

            migrationBuilder.DropColumn(
                name: "symbol",
                schema: "ims",
                table: "investment_tools");
        }
    }
}
