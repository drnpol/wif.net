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
    public class BBWalletImportConfiguration : IEntityTypeConfiguration<BBWalletImport>
    {
        public void Configure(EntityTypeBuilder<BBWalletImport> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_budgetbaker_wallet_import");

            builder.ToTable("budgetbaker_wallet_import");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Account).HasColumnName("account");
            builder.Property(e => e.Amount).HasColumnName("amount");
            builder.Property(e => e.Category).HasColumnName("category");
            builder.Property(e => e.CreatedAt)
                //.HasDefaultValueSql("GETDATE()") // Replaces PostgreSQL's now()
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            builder.Property(e => e.CreatedByUserUid).HasColumnName("created_by_user_uid");
            builder.Property(e => e.Currency).HasColumnName("currency");
            builder.Property(e => e.CustomCategory).HasColumnName("custom_category");
            builder.Property(e => e.Date)
                //.HasColumnType("datetime2") // SQL Server equivalent for timestamp
                .HasColumnType("timestamp")
                .HasColumnName("date");
            builder.Property(e => e.EnvelopeId).HasColumnName("envelope_id");
            builder.Property(e => e.GpsAccuracyInMeters).HasColumnName("gps_accuracy_in_meters");
            builder.Property(e => e.GpsLatitude).HasColumnName("gps_latitude");
            builder.Property(e => e.GpsLongitude).HasColumnName("gps_longitude");
            builder.Property(e => e.Labels).HasColumnName("labels");
            builder.Property(e => e.Note).HasColumnName("note");
            builder.Property(e => e.Payee).HasColumnName("payee");
            builder.Property(e => e.PaymentType).HasColumnName("payment_type");
            builder.Property(e => e.PaymentTypeLocal).HasColumnName("payment_type_local");
            builder.Property(e => e.RefCurrencyAmount).HasColumnName("ref_currency_amount");
            builder.Property(e => e.Transfer).HasColumnName("transfer");
            builder.Property(e => e.Type).HasColumnName("type");
            builder.Property(e => e.Uid)
                //.HasDefaultValueSql("NEWID()") // Replaces PostgreSQL's gen_random_uuid()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("uid");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            builder.Property(e => e.UpdatedByUserUid).HasColumnName("updated_by_user_uid");
            builder.Property(e => e.UserUid).HasColumnName("user_uid");
            builder.Property(e => e.WarrantyInMonth).HasColumnName("warranty_in_month");

            // End of Application / Entity Tables
        }
    }
}
