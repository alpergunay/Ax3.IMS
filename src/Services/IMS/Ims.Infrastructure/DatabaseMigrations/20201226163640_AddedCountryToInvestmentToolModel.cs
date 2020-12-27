using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ims.Infrastructure.DatabaseMigrations
{
    public partial class AddedCountryToInvestmentToolModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_countries_investment_tools_investment_tool_id",
                table: "countries");

            migrationBuilder.DropIndex(
                name: "ix_countries_investment_tool_id",
                table: "countries");

            migrationBuilder.AddColumn<Guid>(
                name: "country_id",
                schema: "ims",
                table: "investment_tools",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "investment_tool_id1",
                table: "countries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_investment_tools_country_id",
                schema: "ims",
                table: "investment_tools",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_countries_investment_tool_id1",
                table: "countries",
                column: "investment_tool_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_countries_investment_tools_investment_tool_id1",
                table: "countries",
                column: "investment_tool_id1",
                principalSchema: "ims",
                principalTable: "investment_tools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_investment_tools_countries_country_id",
                schema: "ims",
                table: "investment_tools",
                column: "country_id",
                principalTable: "countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_countries_investment_tools_investment_tool_id1",
                table: "countries");

            migrationBuilder.DropForeignKey(
                name: "fk_investment_tools_countries_country_id",
                schema: "ims",
                table: "investment_tools");

            migrationBuilder.DropIndex(
                name: "ix_investment_tools_country_id",
                schema: "ims",
                table: "investment_tools");

            migrationBuilder.DropIndex(
                name: "ix_countries_investment_tool_id1",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "country_id",
                schema: "ims",
                table: "investment_tools");

            migrationBuilder.DropColumn(
                name: "investment_tool_id1",
                table: "countries");

            migrationBuilder.CreateIndex(
                name: "ix_countries_investment_tool_id",
                table: "countries",
                column: "investment_tool_id");

            migrationBuilder.AddForeignKey(
                name: "fk_countries_investment_tools_investment_tool_id",
                table: "countries",
                column: "investment_tool_id",
                principalSchema: "ims",
                principalTable: "investment_tools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
