using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ims.Infrastructure.DatabaseMigrations
{
    public partial class UserModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_families_family_id",
                schema: "ims",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "mobile",
                schema: "ims",
                table: "users",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "family_id",
                schema: "ims",
                table: "users",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "local_currency_id",
                schema: "ims",
                table: "users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_local_currency_id",
                schema: "ims",
                table: "users",
                column: "local_currency_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_families_family_id",
                schema: "ims",
                table: "users",
                column: "family_id",
                principalSchema: "ims",
                principalTable: "families",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_users_investment_tools_local_currency_id",
                schema: "ims",
                table: "users",
                column: "local_currency_id",
                principalSchema: "ims",
                principalTable: "investment_tools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_families_family_id",
                schema: "ims",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_users_investment_tools_local_currency_id",
                schema: "ims",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_local_currency_id",
                schema: "ims",
                table: "users");

            migrationBuilder.DropColumn(
                name: "local_currency_id",
                schema: "ims",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "mobile",
                schema: "ims",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "family_id",
                schema: "ims",
                table: "users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_users_families_family_id",
                schema: "ims",
                table: "users",
                column: "family_id",
                principalSchema: "ims",
                principalTable: "families",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
