using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WIF.PortfolioManager.Domain.Enums;
using WIF.PortfolioManager.Domain.Models;

namespace WIF.PortfolioManager.Persistence.Configurations.Entities
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> entity)
        {
            entity.ToTable("port_lu_account_type");
            entity.HasKey(e => e.Id).HasName("PK_port_lu_account_type");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Alias).HasColumnName("alias");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasData(
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.GENERAL,
                    Name = "GENERAL",
                    Alias = String.Empty,
                    Description = "General account type for miscellaneous purposes."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.CASH,
                    Name = "CASH",
                    Alias = String.Empty,
                    Description = "Cash account type for physical cash holdings."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.CURRENT_ACCOUNT,
                    Name = "CURRENT_ACCOUNT",
                    Alias = String.Empty,
                    Description = "Current account type for daily transactions and operations."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.CREDIT_CARD,
                    Name = "CREDIT_CARD",
                    Alias = String.Empty,
                    Description = "Credit card account type for managing credit card transactions."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.SAVINGS_ACCOUNT,
                    Name = "SAVINGS_ACCOUNT",
                    Alias = String.Empty,
                    Description = "Savings account type for holding funds with interest accrual."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.BONUS,
                    Name = "BONUS",
                    Alias = String.Empty,
                    Description = "Bonus account type for rewards or promotional funds."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.INSURANCE,
                    Name = "INSURANCE",
                    Alias = String.Empty,
                    Description = "Insurance account type for managing insurance policies and claims."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.INVESTMENT,
                    Name = "INVESTMENT",
                    Alias = String.Empty,
                    Description = "Investment account type for managing investment portfolios and assets."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.LOAN,
                    Name = "LOAN",
                    Alias = String.Empty,
                    Description = "Loan account type for managing borrowed funds and repayments."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.MORTGAGE,
                    Name = "MORTGAGE",
                    Alias = String.Empty,
                    Description = "Mortgage account type for managing home loans and property financing."
                },
                new AccountType()
                {
                    Id = (int)AccountTypeEnum.ACCOUNT_WITH_OVERDRAFT,
                    Name = "ACCOUNT_WITH_OVERDRAFT",
                    Alias = String.Empty,
                    Description = "Account type that allows overdrafts, enabling users to withdraw more than their current balance."
                }
            );
        }
    }
}
