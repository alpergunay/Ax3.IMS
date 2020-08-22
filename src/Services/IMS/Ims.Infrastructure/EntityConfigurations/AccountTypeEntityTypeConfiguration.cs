using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class AccountTypeEntityTypeConfiguration : BaseEntityTypeConfiguration<AccountType>
    {
        public override void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.ToTable("account_types", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEnum(builder);
        }
    }
}
