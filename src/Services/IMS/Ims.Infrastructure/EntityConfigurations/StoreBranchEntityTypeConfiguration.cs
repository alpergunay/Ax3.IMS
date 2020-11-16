using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class StoreBranchEntityTypeConfiguration : BaseEntityTypeConfiguration<StoreBranch>
    {
        public override void Configure(EntityTypeBuilder<StoreBranch> builder)
        {
            builder.ToTable("store_branches", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEntity(builder);

            builder
                .Property<string>("Name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsRequired();
            builder
                .Property("StoreId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StoreId")
                .IsRequired();
            builder.HasOne(p => p.Store)
                .WithMany()
                .HasForeignKey("StoreId");
        }
    }
}
