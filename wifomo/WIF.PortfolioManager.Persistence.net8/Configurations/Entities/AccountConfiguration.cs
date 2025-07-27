using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WIF.PortfolioManager.Domain.Models;

namespace WIF.PortfolioManager.Persistence.Configurations.Entities
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.ToTable("port_account");
            entity.HasKey(e => e.Uid).HasName("PK_port_account");
            entity.Property(e => e.Uid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("uid");
            entity.Property(e => e.UserUid).HasColumnName("user_uid");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.AccountNo).HasColumnName("account_no");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedByUserUid).HasColumnName("created_by_user_uid");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedByUserUid).HasColumnName("updated_by_user_uid");

            entity.HasOne(e => e.AccountType)
                .WithMany()
                .HasForeignKey(e => e.TypeId)
                .HasConstraintName("FK_account_type");
        }
    }
}
