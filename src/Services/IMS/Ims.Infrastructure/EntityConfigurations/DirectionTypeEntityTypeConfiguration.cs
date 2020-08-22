using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class DirectionTypeEntityTypeConfiguration : BaseEntityTypeConfiguration<DirectionType>
    {
        public override void Configure(EntityTypeBuilder<DirectionType> builder)
        {
            builder.ToTable("direction_types", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEnum(builder);
        }
    }
}
