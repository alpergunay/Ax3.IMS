using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ims.Api.Infrastructure.DatabaseMigrations
{
    public partial class RemovedMandatoryInEnumAudits2 : Migration
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
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "direction_types",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direction_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "families",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "investment_tool_types",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investment_tool_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "store_types",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transaction_types",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    DirectionTypeId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transaction_types_direction_types_DirectionTypeId",
                        column: x => x.DirectionTypeId,
                        principalSchema: "ims",
                        principalTable: "direction_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    FamilyId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_families_FamilyId",
                        column: x => x.FamilyId,
                        principalSchema: "ims",
                        principalTable: "families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "investment_tools",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    InvestmentToolTypeId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investment_tools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_investment_tools_investment_tool_types_InvestmentToolTypeId",
                        column: x => x.InvestmentToolTypeId,
                        principalSchema: "ims",
                        principalTable: "investment_tool_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    StoreTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stores_store_types_StoreTypeId",
                        column: x => x.StoreTypeId,
                        principalSchema: "ims",
                        principalTable: "store_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "investment_tool_prices",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    InvestmentToolId = table.Column<Guid>(nullable: false),
                    BuyingPrice = table.Column<decimal>(type: "decimal(18, 6)", maxLength: 25, nullable: false),
                    PriceDate = table.Column<DateTime>(maxLength: 25, nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(18, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investment_tool_prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_investment_tool_prices_investment_tools_InvestmentToolId",
                        column: x => x.InvestmentToolId,
                        principalSchema: "ims",
                        principalTable: "investment_tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_branches",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_store_branches_stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "ims",
                        principalTable: "stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    StoreBranchId = table.Column<Guid>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    InvestmentToolId = table.Column<Guid>(nullable: false),
                    AccountNo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_account_types_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalSchema: "ims",
                        principalTable: "account_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_investment_tools_InvestmentToolId",
                        column: x => x.InvestmentToolId,
                        principalSchema: "ims",
                        principalTable: "investment_tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_store_branches_StoreBranchId",
                        column: x => x.StoreBranchId,
                        principalSchema: "ims",
                        principalTable: "store_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ims",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_transactions",
                schema: "ims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Modifier = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    TransactionTypeId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 6)", maxLength: 25, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 6)", maxLength: 25, nullable: false),
                    TransactionDate = table.Column<DateTime>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_account_transactions_accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "ims",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_account_transactions_transaction_types_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalSchema: "ims",
                        principalTable: "transaction_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_transactions_AccountId",
                schema: "ims",
                table: "account_transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_account_transactions_TransactionTypeId",
                schema: "ims",
                table: "account_transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_AccountTypeId",
                schema: "ims",
                table: "accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_InvestmentToolId",
                schema: "ims",
                table: "accounts",
                column: "InvestmentToolId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_StoreBranchId",
                schema: "ims",
                table: "accounts",
                column: "StoreBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_UserId",
                schema: "ims",
                table: "accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_investment_tool_prices_InvestmentToolId",
                schema: "ims",
                table: "investment_tool_prices",
                column: "InvestmentToolId");

            migrationBuilder.CreateIndex(
                name: "IX_investment_tools_InvestmentToolTypeId",
                schema: "ims",
                table: "investment_tools",
                column: "InvestmentToolTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_store_branches_StoreId",
                schema: "ims",
                table: "store_branches",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_stores_StoreTypeId",
                schema: "ims",
                table: "stores",
                column: "StoreTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_types_DirectionTypeId",
                schema: "ims",
                table: "transaction_types",
                column: "DirectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_users_FamilyId",
                schema: "ims",
                table: "users",
                column: "FamilyId");
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
