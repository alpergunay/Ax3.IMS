using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Api.Data.Migrations.ApplicationDb
{
    public partial class ApplicationUserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sur_name",
                table: "AspNetUsers",
                newName: "surname");

            migrationBuilder.AlterColumn<string>(
                name: "mobile_phone_number",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "surname",
                table: "AspNetUsers",
                newName: "sur_name");

            migrationBuilder.AlterColumn<string>(
                name: "mobile_phone_number",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
