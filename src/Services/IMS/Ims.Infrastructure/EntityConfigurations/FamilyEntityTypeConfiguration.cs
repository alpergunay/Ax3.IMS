using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class FamilyEntityTypeConfiguration : BaseEntityTypeConfiguration<Family>
    {
        public override void Configure(EntityTypeBuilder<Family> builder)
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
                .Property("_userId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("UserId")
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey("_userId");
        }
    }
}
