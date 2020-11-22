using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Infrastructure.EntityConfigurations
{
    public class AccountEntityTypeConfiguration : BaseEntityTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts", ImsContext.DEFAULT_SCHEMA);
            base.ConfigureForEntity(builder);

            builder
                .Property<string>("AccountNo")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AccountNo")
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property<string>("AccountName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AccountName")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey("UserId");

            builder
                .Property("StoreBranchId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StoreBranchId")
                .IsRequired();

            builder.HasOne(p => p.StoreBranch)
                .WithMany()
                .HasForeignKey("StoreBranchId");

            builder
                .Property("AccountTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AccountTypeId")
                .IsRequired();

            builder.HasOne(p => p.AccountType)
                .WithMany()
                .HasForeignKey("AccountTypeId");

            builder
                .Property("InvestmentToolId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("InvestmentToolId")
                .IsRequired();

            builder.HasOne(p => p.InvestmentTool)
                .WithMany()
                .HasForeignKey("InvestmentToolId");
        }
    }
}
