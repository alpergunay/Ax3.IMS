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
                .Property(a=>a.AccountId)
                .IsRequired();

            builder.HasOne(p => p.Account)
                .WithMany(at=>at.AccountTransactions)
                .HasForeignKey(k=>k.AccountId);

            builder
                .Property("TransactionTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("TransactionTypeId")
                .IsRequired();

            builder.HasOne(p => p.TransactionType)
                .WithMany()
                .HasForeignKey("TransactionTypeId");

            builder
                .Property<DateTime>("TransactionDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("TransactionDate")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property<double>("Amount")
                .HasColumnType("decimal(18, 6)")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Amount")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property<double>("Rate")
                .HasColumnType("decimal(18, 6)")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Rate")
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
