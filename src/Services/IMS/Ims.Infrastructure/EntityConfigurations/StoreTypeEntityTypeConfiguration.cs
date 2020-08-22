using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class StoreTypeEntityTypeConfiguration : BaseEntityTypeConfiguration<StoreType>
    {
        public override void Configure(EntityTypeBuilder<StoreType> builder)
        {
            builder.ToTable("store_types", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEnum(builder);
        }
    }
}
