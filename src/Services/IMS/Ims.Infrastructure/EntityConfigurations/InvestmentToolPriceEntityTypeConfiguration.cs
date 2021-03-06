﻿using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class InvestmentToolPriceEntityTypeConfiguration : BaseEntityTypeConfiguration<InvestmentToolPrice>
    {
        public override void Configure(EntityTypeBuilder<InvestmentToolPrice> builder)
        {
            builder.ToTable("investment_tool_prices", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEntity(builder);

            builder
                .Property<DateTime>("PriceDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PriceDate")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property<double>("SalesPrice")
                .HasColumnType("decimal(18, 6)")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("SalesPrice")
                .IsRequired();

            builder
                .Property<double>("BuyingPrice")
                .HasColumnType("decimal(18, 6)")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("BuyingPrice")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property("InvestmentToolId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("InvestmentToolId")
                .IsRequired();

            builder.HasOne(p => p.InvestmentTool)
                .WithMany()
                .HasForeignKey("InvestmentToolId");

        }
    }
}
