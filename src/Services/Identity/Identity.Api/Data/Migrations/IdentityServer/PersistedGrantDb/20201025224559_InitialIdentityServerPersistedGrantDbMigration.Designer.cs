﻿// <auto-generated />
using System;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Identity.Api.Data.Migrations.IdentityServer.PersistedGrantDb
{
    [DbContext(typeof(PersistedGrantDbContext))]
    [Migration("20201025224559_InitialIdentityServerPersistedGrantDbMigration")]
    partial class InitialIdentityServerPersistedGrantDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasColumnName("user_code")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnName("client_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnName("data")
                        .HasColumnType("character varying(50000)")
                        .HasMaxLength(50000);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasColumnName("device_code")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnName("expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SessionId")
                        .HasColumnName("session_id")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SubjectId")
                        .HasColumnName("subject_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("UserCode")
                        .HasName("pk_device_codes");

                    b.HasIndex("DeviceCode")
                        .IsUnique()
                        .HasName("ix_device_codes_device_code");

                    b.HasIndex("Expiration")
                        .HasName("ix_device_codes_expiration");

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnName("key")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnName("client_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnName("consumed_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnName("data")
                        .HasColumnType("character varying(50000)")
                        .HasMaxLength(50000);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnName("expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SessionId")
                        .HasColumnName("session_id")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SubjectId")
                        .HasColumnName("subject_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Key")
                        .HasName("pk_persisted_grants");

                    b.HasIndex("Expiration")
                        .HasName("ix_persisted_grants_expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type")
                        .HasName("ix_persisted_grants_subject_id_client_id_type");

                    b.HasIndex("SubjectId", "SessionId", "Type")
                        .HasName("ix_persisted_grants_subject_id_session_id_type");

                    b.ToTable("PersistedGrants");
                });
#pragma warning restore 612, 618
        }
    }
}
