using Ax3.IMS.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ims.Infrastructure.EntityConfigurations
{
    public abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {}
        protected virtual void ConfigureForEntity(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.Id)
                .IsRequired();

            ConfigureAuditFields(builder, typeof(Entity));
        }
        protected virtual void ConfigureForEnum<TEnum>(EntityTypeBuilder<TEnum> builder) where TEnum : Enumeration
        {
            builder.HasKey(rt => rt.EnumId);
            builder.Ignore(c => c.Id);

            builder.Property(rt => rt.EnumId)
                .HasColumnName("Id")
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(rt => rt.Code)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(rt => rt.Name)
                .HasMaxLength(200)
                .IsRequired();

            ConfigureAuditFields(builder, typeof(Enumeration));
        }
        private void ConfigureAuditFields<T>(EntityTypeBuilder<T> builder, Type typeofT) where T : Entity
        {
            if(typeofT == typeof(Enumeration))
            {
                builder.Property<string>(x => x.Creator).IsRequired(false);
                builder.Property<string>(c => c.Modifier).IsRequired(false);
            }
            else
            {
                builder.Property<string>(x => x.Creator).IsRequired();
                builder.Property<string>(c => c.Modifier).IsRequired();
            }
            builder.Property<DateTime>(x => x.CreatedOn).IsRequired();
            builder.Property<DateTime>(x => x.ModifiedOn).IsRequired();
        }
    }
}
