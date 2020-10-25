using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class StoreEntityTypeConfiguration : BaseEntityTypeConfiguration<Store>
    {
        public override void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("stores", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEntity(builder);

            builder
                .Property<string>("Name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsRequired();
            builder
                .Property("StoreTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StoreTypeId")
                .IsRequired();
            builder.HasOne(p => p.StoreType)
                .WithMany()
                .HasForeignKey("StoreTypeId");
        }
    }
}
