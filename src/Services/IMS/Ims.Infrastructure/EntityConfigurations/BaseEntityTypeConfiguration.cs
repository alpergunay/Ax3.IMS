using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.Id)
                .IsRequired();

            ConfigureAuditFields(builder);
        }
        private void ConfigureAuditFields(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property<DateTime>(x => x.CreatedOn).IsRequired();
            builder.Property<DateTime>(x => x.ModifiedOn).IsRequired();
            builder.Property<string>(x => x.Creator).IsRequired();
            builder.Property<string>(c => c.Modifier).IsRequired();
        }
    }
}
