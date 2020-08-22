using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class TransactionTypeEntityTypeConfiguration : BaseEntityTypeConfiguration<TransactionType>
    {
        public override void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("transaction_types", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEntity(builder);

            builder
                .Property<string>("_code")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Code")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property<string>("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property("_directionTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DirectionTypeId")
                .IsRequired();

            builder.HasOne(p => p.DirectionType)
                .WithMany()
                .HasForeignKey("_directionTypeId");
        }
    }
}
