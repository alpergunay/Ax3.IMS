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
            builder
                .Property("DirectionTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DirectionTypeId")
                .IsRequired();

            builder.HasOne(p => p.DirectionType)
                .WithMany()
                .HasForeignKey("DirectionTypeId");

            base.ConfigureForEnum(builder);
        }
    }
}
