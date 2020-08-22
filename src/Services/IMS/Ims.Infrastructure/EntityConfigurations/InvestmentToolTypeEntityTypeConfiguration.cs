using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class InvestmentToolTypeEntityTypeConfiguration : BaseEntityTypeConfiguration<InvestmentToolType>
    {
        public override void Configure(EntityTypeBuilder<InvestmentToolType> builder)
        {
            builder.ToTable("investment_tool_types", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEnum(builder);
        }
    }
}
