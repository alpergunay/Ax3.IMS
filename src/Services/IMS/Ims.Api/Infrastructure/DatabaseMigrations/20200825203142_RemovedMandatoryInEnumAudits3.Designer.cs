﻿// <auto-generated />
using System;
using Ims.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ims.Api.Infrastructure.DatabaseMigrations
{
    [DbContext(typeof(ImsContext))]
    [Migration("20200825203142_RemovedMandatoryInEnumAudits3")]
    partial class RemovedMandatoryInEnumAudits3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_accountNo")
                        .IsRequired()
                        .HasColumnName("AccountNo")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("_accountTypeId")
                        .HasColumnName("AccountTypeId")
                        .HasColumnType("integer");

                    b.Property<Guid>("_investmentToolId")
                        .HasColumnName("InvestmentToolId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_storeBranchId")
                        .HasColumnName("StoreBranchId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_userId")
                        .HasColumnName("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("_accountTypeId");

                    b.HasIndex("_investmentToolId");

                    b.HasIndex("_storeBranchId");

                    b.HasIndex("_userId");

                    b.ToTable("accounts","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.AccountTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("_accountId")
                        .HasColumnName("AccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("_amount")
                        .HasColumnName("Amount")
                        .HasColumnType("decimal(18, 6)")
                        .HasMaxLength(25);

                    b.Property<decimal>("_rate")
                        .HasColumnName("Rate")
                        .HasColumnType("decimal(18, 6)")
                        .HasMaxLength(25);

                    b.Property<DateTime>("_transactionDate")
                        .HasColumnName("TransactionDate")
                        .HasColumnType("timestamp without time zone")
                        .HasMaxLength(25);

                    b.Property<Guid>("_transactionTypeId")
                        .HasColumnName("TransactionTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("_accountId");

                    b.HasIndex("_transactionTypeId");

                    b.ToTable("account_transactions","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.AccountType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId");

                    b.ToTable("account_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.DirectionType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId");

                    b.ToTable("direction_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("families","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentTool", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_code")
                        .IsRequired()
                        .HasColumnName("Code")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<int>("_investmentToolTypeId")
                        .HasColumnName("InvestmentToolTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("_investmentToolTypeId");

                    b.ToTable("investment_tools","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentToolPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("_buyingPrice")
                        .HasColumnName("BuyingPrice")
                        .HasColumnType("decimal(18, 6)")
                        .HasMaxLength(25);

                    b.Property<Guid>("_investmentToolId")
                        .HasColumnName("InvestmentToolId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("_priceDate")
                        .HasColumnName("PriceDate")
                        .HasColumnType("timestamp without time zone")
                        .HasMaxLength(25);

                    b.Property<decimal>("_salesPrice")
                        .HasColumnName("SalesPrice")
                        .HasColumnType("decimal(18, 6)");

                    b.HasKey("Id");

                    b.HasIndex("_investmentToolId");

                    b.ToTable("investment_tool_prices","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentToolType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId");

                    b.ToTable("investment_tool_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<int>("_storeTypeId")
                        .HasColumnName("StoreTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("_storeTypeId");

                    b.ToTable("stores","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.StoreBranch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("_storeId")
                        .HasColumnName("StoreId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("_storeId");

                    b.ToTable("store_branches","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.StoreType", b =>
                {
                    b.Property<int>("EnumId")
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("EnumId");

                    b.ToTable("store_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.TransactionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_code")
                        .IsRequired()
                        .HasColumnName("Code")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<int>("_directionTypeId")
                        .HasColumnName("DirectionTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("_directionTypeId");

                    b.ToTable("transaction_types","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Modifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("_familyId")
                        .HasColumnName("FamilyId")
                        .HasColumnType("uuid");

                    b.Property<string>("_mobile")
                        .IsRequired()
                        .HasColumnName("Mobile")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("_surname")
                        .IsRequired()
                        .HasColumnName("Surname")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("_familyId");

                    b.ToTable("users","ims");
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Account", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("_accountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ims.Domain.DomainModels.InvestmentTool", "InvestmentTool")
                        .WithMany()
                        .HasForeignKey("_investmentToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ims.Domain.DomainModels.StoreBranch", "StoreBranch")
                        .WithMany()
                        .HasForeignKey("_storeBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ims.Domain.DomainModels.User", "User")
                        .WithMany()
                        .HasForeignKey("_userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.AccountTransaction", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.Account", "Account")
                        .WithMany()
                        .HasForeignKey("_accountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ims.Domain.DomainModels.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("_transactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentTool", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.InvestmentToolType", "InvestmentToolType")
                        .WithMany()
                        .HasForeignKey("_investmentToolTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.InvestmentToolPrice", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.InvestmentTool", "InvestmentTool")
                        .WithMany()
                        .HasForeignKey("_investmentToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.Store", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.StoreType", "StoreType")
                        .WithMany()
                        .HasForeignKey("_storeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.StoreBranch", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.Store", "Store")
                        .WithMany()
                        .HasForeignKey("_storeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.TransactionType", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.DirectionType", "DirectionType")
                        .WithMany()
                        .HasForeignKey("_directionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ims.Domain.DomainModels.User", b =>
                {
                    b.HasOne("Ims.Domain.DomainModels.Family", "Family")
                        .WithMany()
                        .HasForeignKey("_familyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}