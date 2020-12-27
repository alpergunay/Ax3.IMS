using Microsoft.EntityFrameworkCore.Migrations;

namespace Ims.Infrastructure.DatabaseMigrations
{
    public partial class CountryTableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_country_investment_tools_investment_tool_id",
                table: "country");

            migrationBuilder.DropForeignKey(
                name: "fk_users_country_country_id",
                schema: "ims",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_country",
                table: "country");

            migrationBuilder.RenameTable(
                name: "country",
                newName: "countries");

            migrationBuilder.RenameIndex(
                name: "ix_country_investment_tool_id",
                table: "countries",
                newName: "ix_countries_investment_tool_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_countries",
                table: "countries",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_countries_investment_tools_investment_tool_id",
                table: "countries",
                column: "investment_tool_id",
                principalSchema: "ims",
                principalTable: "investment_tools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_users_countries_country_id",
                schema: "ims",
                table: "users",
                column: "country_id",
                principalTable: "countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_countries_investment_tools_investment_tool_id",
                table: "countries");

            migrationBuilder.DropForeignKey(
                name: "fk_users_countries_country_id",
                schema: "ims",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_countries",
                table: "countries");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "country");

            migrationBuilder.RenameIndex(
                name: "ix_countries_investment_tool_id",
                table: "country",
                newName: "ix_country_investment_tool_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_country",
                table: "country",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_country_investment_tools_investment_tool_id",
                table: "country",
                column: "investment_tool_id",
                principalSchema: "ims",
                principalTable: "investment_tools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_users_country_country_id",
                schema: "ims",
                table: "users",
                column: "country_id",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
