using System;
using System.Collections.Generic;
using System.Text;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class AccountTransactionEntityTypeConfiguration : BaseEntityTypeConfiguration<AccountTransaction>
    {
        public override void Configure(EntityTypeBuilder<AccountTransaction> builder)
        {
            builder.ToTable("account_transactions", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEntity(builder);

            builder
                .Property("_accountId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AccountId")
                .IsRequired();

            builder.HasOne(p => p.Account)
                .WithMany()
                .HasForeignKey("_accountId");

            builder
                .Property("_transactionTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("TransactionTypeId")
                .IsRequired();

            builder.HasOne(p => p.TransactionType)
                .WithMany()
                .HasForeignKey("_transactionTypeId");

            builder
                .Property<DateTime>("_transactionDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("TransactionDate")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property<double>("_amount")
                .HasColumnType("decimal(18, 6)")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Amount")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property<double>("_rate")
                .HasColumnType("decimal(18, 6)")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Rate")
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
