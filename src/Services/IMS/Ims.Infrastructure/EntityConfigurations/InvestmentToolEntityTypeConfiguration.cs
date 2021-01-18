using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class InvestmentToolEntityTypeConfiguration : BaseEntityTypeConfiguration<InvestmentTool>
    {
        public override void Configure(EntityTypeBuilder<InvestmentTool> builder)
        {
            builder.ToTable("investment_tools", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEntity(builder);

            builder
                .Property<string>("Code")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Code")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property<string>("Name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property<string>("Symbol")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Symbol")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property("InvestmentToolTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("InvestmentToolTypeId")
                .IsRequired();

            builder.HasOne(p => p.InvestmentToolType)
                .WithMany()
                .HasForeignKey("InvestmentToolTypeId");
        }
    }
}
