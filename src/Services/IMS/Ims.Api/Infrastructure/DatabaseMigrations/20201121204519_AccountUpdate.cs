using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ims.Infrastructure.Migrations
{
    public partial class AccountUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ims");

            migrationBuilder.CreateTable(
                name: "account_types",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, defaultValue: 1),
                    creator = table.Column<string>(nullable: true),
                    modifier = table.Column<string>(nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(maxLength: 200, nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "direction_types",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, defaultValue: 1),
                    creator = table.Column<string>(nullable: true),
                    modifier = table.Column<string>(nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(maxLength: 200, nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_direction_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "families",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_families", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "investment_tool_types",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, defaultValue: 1),
                    creator = table.Column<string>(nullable: true),
                    modifier = table.Column<string>(nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(maxLength: 200, nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_investment_tool_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "store_types",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, defaultValue: 1),
                    creator = table.Column<string>(nullable: true),
                    modifier = table.Column<string>(nullable: true),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(maxLength: 200, nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_store_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transaction_types",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(maxLength: 20, nullable: false),
                    description = table.Column<string>(maxLength: 200, nullable: false),
                    direction_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transaction_types", x => x.id);
                    table.ForeignKey(
                        name: "fk_transaction_types_direction_types_direction_type_enum_id",
                        column: x => x.direction_type_id,
                        principalSchema: "ims",
                        principalTable: "direction_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    user_name = table.Column<string>(nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    surname = table.Column<string>(maxLength: 50, nullable: false),
                    mobile = table.Column<string>(maxLength: 20, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    family_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_families_family_id",
                        column: x => x.family_id,
                        principalSchema: "ims",
                        principalTable: "families",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "investment_tools",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(maxLength: 20, nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    investment_tool_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_investment_tools", x => x.id);
                    table.ForeignKey(
                        name: "fk_investment_tools_investment_tool_types_investment_tool_type_id",
                        column: x => x.investment_tool_type_id,
                        principalSchema: "ims",
                        principalTable: "investment_tool_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    store_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stores", x => x.id);
                    table.ForeignKey(
                        name: "fk_stores_store_types_store_type_id",
                        column: x => x.store_type_id,
                        principalSchema: "ims",
                        principalTable: "store_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "investment_tool_prices",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    investment_tool_id = table.Column<Guid>(nullable: false),
                    buying_price = table.Column<decimal>(type: "decimal(18, 6)", maxLength: 25, nullable: false),
                    price_date = table.Column<DateTime>(maxLength: 25, nullable: false),
                    sales_price = table.Column<decimal>(type: "decimal(18, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_investment_tool_prices", x => x.id);
                    table.ForeignKey(
                        name: "fk_investment_tool_prices_investment_tools_investment_tool_id",
                        column: x => x.investment_tool_id,
                        principalSchema: "ims",
                        principalTable: "investment_tools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_branches",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    store_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_store_branches", x => x.id);
                    table.ForeignKey(
                        name: "fk_store_branches_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "ims",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    store_branch_id = table.Column<Guid>(nullable: false),
                    account_type_id = table.Column<int>(nullable: false),
                    investment_tool_id = table.Column<Guid>(nullable: false),
                    account_no = table.Column<string>(maxLength: 50, nullable: false),
                    account_name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_accounts_account_types_account_type_id",
                        column: x => x.account_type_id,
                        principalSchema: "ims",
                        principalTable: "account_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_accounts_investment_tools_investment_tool_id",
                        column: x => x.investment_tool_id,
                        principalSchema: "ims",
                        principalTable: "investment_tools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_accounts_store_branches_store_branch_id",
                        column: x => x.store_branch_id,
                        principalSchema: "ims",
                        principalTable: "store_branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_accounts_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "ims",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_transactions",
                schema: "ims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    creator = table.Column<string>(nullable: false),
                    modifier = table.Column<string>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    modified_on = table.Column<DateTime>(nullable: false),
                    account_id = table.Column<Guid>(nullable: false),
                    transaction_type_id = table.Column<Guid>(nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18, 6)", maxLength: 25, nullable: false),
                    rate = table.Column<decimal>(type: "decimal(18, 6)", maxLength: 25, nullable: false),
                    transaction_date = table.Column<DateTime>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_transactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_transactions_accounts_account_id",
                        column: x => x.account_id,
                        principalSchema: "ims",
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_transactions_transaction_types_transaction_type_id",
                        column: x => x.transaction_type_id,
                        principalSchema: "ims",
                        principalTable: "transaction_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_transactions_account_id",
                schema: "ims",
                table: "account_transactions",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_transactions_transaction_type_id",
                schema: "ims",
                table: "account_transactions",
                column: "transaction_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_account_type_id",
                schema: "ims",
                table: "accounts",
                column: "account_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_investment_tool_id",
                schema: "ims",
                table: "accounts",
                column: "investment_tool_id");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_store_branch_id",
                schema: "ims",
                table: "accounts",
                column: "store_branch_id");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_user_id",
                schema: "ims",
                table: "accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_investment_tool_prices_investment_tool_id",
                schema: "ims",
                table: "investment_tool_prices",
                column: "investment_tool_id");

            migrationBuilder.CreateIndex(
                name: "ix_investment_tools_investment_tool_type_id",
                schema: "ims",
                table: "investment_tools",
                column: "investment_tool_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_store_branches_store_id",
                schema: "ims",
                table: "store_branches",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "ix_stores_store_type_id",
                schema: "ims",
                table: "stores",
                column: "store_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_transaction_types_direction_type_id",
                schema: "ims",
                table: "transaction_types",
                column: "direction_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_family_id",
                schema: "ims",
                table: "users",
                column: "family_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_transactions",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "investment_tool_prices",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "transaction_types",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "account_types",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "investment_tools",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "store_branches",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "users",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "direction_types",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "investment_tool_types",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "families",
                schema: "ims");

            migrationBuilder.DropTable(
                name: "store_types",
                schema: "ims");
        }
    }
}
