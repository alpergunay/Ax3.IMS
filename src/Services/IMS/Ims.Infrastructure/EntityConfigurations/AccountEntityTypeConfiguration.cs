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
                .Property<string>("_accountNo")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AccountNo")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property("_userId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("UserId")
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey("_userId");

            builder
                .Property("_storeBranchId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StoreBranchId")
                .IsRequired();

            builder.HasOne(p => p.StoreBranch)
                .WithMany()
                .HasForeignKey("_storeBranchId");

            builder
                .Property("_accountTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AccountTypeId")
                .IsRequired();

            builder.HasOne(p => p.AccountType)
                .WithMany()
                .HasForeignKey("_accountTypeId");

            builder
                .Property("_investmentToolId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("InvestmentToolId")
                .IsRequired();

            builder.HasOne(p => p.InvestmentTool)
                .WithMany()
                .HasForeignKey("_investmentToolId");
        }
    }
}
