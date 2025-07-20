using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WIF.Core.Models;

namespace WIF.Core.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public virtual DbSet<BBWalletImport> BBWalletImports { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }

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

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("port_lu_account_type");
                entity.HasKey(e => e.Id).HasName("PK_port_lu_account_type");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Alias).HasColumnName("alias");
                entity.Property(e => e.Description).HasColumnName("description");
            });

            modelBuilder.Entity<Account>(entity =>
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
            });
        }
    }
}
