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
                .Property<string>("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property<string>("_surname")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Surname")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property<string>("_mobile")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Mobile")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property<string>("_email")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
