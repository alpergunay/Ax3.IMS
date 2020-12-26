using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEntity(builder);

            builder
                .Property<string>("Name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property<string>("Surname")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Surname")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property("FamilyId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("FamilyId")
                .IsRequired(false);
            builder.HasOne(p => p.Family)
                .WithMany()
                .HasForeignKey("FamilyId");

            builder
                .Property<string>("Mobile")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Mobile")
                .HasMaxLength(20)
                .IsRequired(false);

            builder
                .Property<string>("Email")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property("LocalCurrencyId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("LocalCurrencyId")
                .IsRequired(false);
            builder.HasOne(p => p.LocalCurrency)
                .WithMany()
                .HasForeignKey("LocalCurrencyId");
        }
    }
}
