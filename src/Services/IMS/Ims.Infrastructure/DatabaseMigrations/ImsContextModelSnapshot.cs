﻿// <auto-generated />
using System;
using Ims.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ims.Infrastructure.DatabaseMigrations
{
    [DbContext(typeof(ImsContext))]
    partial class ImsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Ims.Domain.DomainModels.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnName("account_name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasColumnName("account_no")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("AccountTypeId")
                        .HasColumnName("account_type_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<Guid>("InvestmentToolId")
                        .HasColumnName("investment_tool_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<Guid>("StoreBranchId")
                        .HasColumnName("store_branch_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.HasIndex("AccountTypeId")
                        .HasName("ix_accounts_account_type_id");

                    b.HasIndex("InvestmentToolId")
                        .HasName("ix_accounts_investment_tool_id");

                    b.HasIndex("StoreBranchId")
                        .HasName("ix_accounts_store_branch_id");

                    b.HasIndex("UserId")
                        .HasName("ix_accounts_user_id");

                    b.ToTable("accounts","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.AccountTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnName("account_id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("decimal(18, 6)")
                        .HasMaxLength(25);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<decimal>("Rate")
                        .HasColumnName("rate")
                        .HasColumnType("decimal(18, 6)")
                        .HasMaxLength(25);

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnName("transaction_date")
                        .HasColumnType("timestamp without time zone")
                        .HasMaxLength(25);

                    b.Property<int>("TransactionTypeId")
                        .HasColumnName("transaction_type_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_account_transactions");

                    b.HasIndex("AccountId")
                        .HasName("ix_account_transactions_account_id");

                    b.HasIndex("TransactionTypeId")
                        .HasName("ix_account_transactions_transaction_type_id");

                    b.ToTable("account_transactions","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.AccountType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId")
                        .HasName("pk_account_types");

                    b.ToTable("account_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<Guid?>("InvestmentToolId")
                        .HasColumnName("investment_tool_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("pk_countries");

                    b.HasIndex("InvestmentToolId")
                        .HasName("ix_countries_investment_tool_id");

                    b.ToTable("countries","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.DirectionType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId")
                        .HasName("pk_direction_types");

                    b.ToTable("direction_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("pk_families");

                    b.ToTable("families","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentTool", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<int>("InvestmentToolTypeId")
                        .HasColumnName("investment_tool_type_id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnName("symbol")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id")
                        .HasName("pk_investment_tools");

                    b.HasIndex("InvestmentToolTypeId")
                        .HasName("ix_investment_tools_investment_tool_type_id");

                    b.ToTable("investment_tools","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentToolPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("BuyingPrice")
                        .HasColumnName("buying_price")
                        .HasColumnType("decimal(18, 6)")
                        .HasMaxLength(25);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<Guid>("InvestmentToolId")
                        .HasColumnName("investment_tool_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<DateTime>("PriceDate")
                        .HasColumnName("price_date")
                        .HasColumnType("timestamp without time zone")
                        .HasMaxLength(25);

                    b.Property<decimal>("SalesPrice")
                        .HasColumnName("sales_price")
                        .HasColumnType("decimal(18, 6)");

                    b.HasKey("Id")
                        .HasName("pk_investment_tool_prices");

                    b.HasIndex("InvestmentToolId")
                        .HasName("ix_investment_tool_prices_investment_tool_id");

                    b.ToTable("investment_tool_prices","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentToolType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId")
                        .HasName("pk_investment_tool_types");

                    b.ToTable("investment_tool_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<int>("StoreTypeId")
                        .HasColumnName("store_type_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_stores");

                    b.HasIndex("StoreTypeId")
                        .HasName("ix_stores_store_type_id");

                    b.ToTable("stores","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.StoreBranch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("pk_store_branches");

                    b.HasIndex("StoreId")
                        .HasName("ix_store_branches_store_id");

                    b.ToTable("store_branches","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.StoreType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId")
                        .HasName("pk_store_types");

                    b.ToTable("store_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.TransactionType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<int>("DirectionTypeId")
                        .HasColumnName("direction_type_id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId")
                        .HasName("pk_transaction_types");

                    b.HasIndex("DirectionTypeId")
                        .HasName("ix_transaction_types_direction_type_id");

                    b.ToTable("transaction_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CountryId")
                        .HasColumnName("country_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnName("creator")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("FamilyId")
                        .HasColumnName("family_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LocalCurrencyId")
                        .HasColumnName("local_currency_id")
                        .HasColumnType("uuid");

                    b.Property<string>("Mobile")
                        .HasColumnName("mobile")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnName("modified_on")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnName("modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("surname")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("CountryId")
                        .HasName("ix_users_country_id");

                    b.HasIndex("FamilyId")
                        .HasName("ix_users_family_id");

                    b.HasIndex("LocalCurrencyId")
                        .HasName("ix_users_local_currency_id");

                    b.ToTable("users","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Account", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .HasConstraintName("fk_accounts_account_types_account_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ims.Domain.DomainModels.InvestmentTool", "InvestmentTool")
                        .WithMany()
                        .HasForeignKey("InvestmentToolId")
                        .HasConstraintName("fk_accounts_investment_tools_investment_tool_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ims.Domain.DomainModels.StoreBranch", "StoreBranch")
                        .WithMany()
                        .HasForeignKey("StoreBranchId")
                        .HasConstraintName("fk_accounts_store_branches_store_branch_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ims.Domain.DomainModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_accounts_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.AccountTransaction", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.Account", "Account")
                        .WithMany("AccountTransactions")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("fk_account_transactions_accounts_account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ims.Domain.DomainModels.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .HasConstraintName("fk_account_transactions_transaction_types_transaction_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Country", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.InvestmentTool", "InvestmentTool")
                        .WithMany()
                        .HasForeignKey("InvestmentToolId")
                        .HasConstraintName("fk_countries_investment_tools_investment_tool_id");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentTool", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.InvestmentToolType", "InvestmentToolType")
                        .WithMany()
                        .HasForeignKey("InvestmentToolTypeId")
                        .HasConstraintName("fk_investment_tools_investment_tool_types_investment_tool_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentToolPrice", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.InvestmentTool", "InvestmentTool")
                        .WithMany()
                        .HasForeignKey("InvestmentToolId")
                        .HasConstraintName("fk_investment_tool_prices_investment_tools_investment_tool_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Store", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.StoreType", "StoreType")
                        .WithMany()
                        .HasForeignKey("StoreTypeId")
                        .HasConstraintName("fk_stores_store_types_store_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.StoreBranch", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .HasConstraintName("fk_store_branches_stores_store_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.TransactionType", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.DirectionType", "DirectionType")
                        .WithMany()
                        .HasForeignKey("DirectionTypeId")
                        .HasConstraintName("fk_transaction_types_direction_types_direction_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.User", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .HasConstraintName("fk_users_countries_country_id");

                    b.HasOne("Ims.Domain.DomainModels.Family", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyId")
                        .HasConstraintName("fk_users_families_family_id");

                    b.HasOne("Ims.Domain.DomainModels.InvestmentTool", "LocalCurrency")
                        .WithMany()
                        .HasForeignKey("LocalCurrencyId")
                        .HasConstraintName("fk_users_investment_tools_local_currency_id");
                });
#pragma warning restore 612, 618
        }
    }
}
