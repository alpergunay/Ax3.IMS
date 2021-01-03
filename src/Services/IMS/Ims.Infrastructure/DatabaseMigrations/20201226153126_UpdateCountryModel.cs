using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ims.Infrastructure.DatabaseMigrations
{
    public partial class UpdateCountryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_country_investment_tools_investment_tool_id",
                table: "country");

            migrationBuilder.AlterColumn<Guid>(
                name: "investment_tool_id",
                table: "country",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_country_investment_tools_investment_tool_id",
                table: "country",
                column: "investment_tool_id",
                principalSchema: "ims",
                principalTable: "investment_tools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_country_investment_tools_investment_tool_id",
                table: "country");

            migrationBuilder.AlterColumn<Guid>(
                name: "investment_tool_id",
                table: "country",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_country_investment_tools_investment_tool_id",
                table: "country",
                column: "investment_tool_id",
                principalSchema: "ims",
                principalTable: "investment_tools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
