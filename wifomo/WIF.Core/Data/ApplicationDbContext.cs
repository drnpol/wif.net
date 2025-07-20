using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WIF.Core.Models;

namespace WIF.Core.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public virtual DbSet<BBWalletImport> BBWalletImports { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<BBWalletImport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_budgetbaker_wallet_import");

                entity.ToTable("budgetbaker_wallet_import");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Account).HasColumnName("account");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.Category).HasColumnName("category");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETDATE()") // Replaces PostgreSQL's now()
                    .HasDefaultValueSql("now()")
                    .HasColumnName("created_at");
                entity.Property(e => e.CreatedByUserUid).HasColumnName("created_by_user_uid");
                entity.Property(e => e.Currency).HasColumnName("currency");
                entity.Property(e => e.CustomCategory).HasColumnName("custom_category");
                entity.Property(e => e.Date)
                    //.HasColumnType("datetime2") // SQL Server equivalent for timestamp
                    .HasColumnType("timestamp")
                    .HasColumnName("date");
                entity.Property(e => e.EnvelopeId).HasColumnName("envelope_id");
                entity.Property(e => e.GpsAccuracyInMeters).HasColumnName("gps_accuracy_in_meters");
                entity.Property(e => e.GpsLatitude).HasColumnName("gps_latitude");
                entity.Property(e => e.GpsLongitude).HasColumnName("gps_longitude");
                entity.Property(e => e.Labels).HasColumnName("labels");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.Payee).HasColumnName("payee");
                entity.Property(e => e.PaymentType).HasColumnName("payment_type");
                entity.Property(e => e.PaymentTypeLocal).HasColumnName("payment_type_local");
                entity.Property(e => e.RefCurrencyAmount).HasColumnName("ref_currency_amount");
                entity.Property(e => e.Transfer).HasColumnName("transfer");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.Uid)
                    //.HasDefaultValueSql("NEWID()") // Replaces PostgreSQL's gen_random_uuid()
                    .HasDefaultValueSql("gen_random_uuid()")
                    .HasColumnName("uid");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.UpdatedByUserUid).HasColumnName("updated_by_user_uid");
                entity.Property(e => e.UserUid).HasColumnName("user_uid");
                entity.Property(e => e.WarrantyInMonth).HasColumnName("warranty_in_month");

                // End of Application / Entity Tables
            });
        }
    }
}
