using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WIF.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAndBBWalletImport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "budgetbaker_wallet_import",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uid = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "NEWID()"),
                    user_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true),
                    ref_currency_amount = table.Column<double>(type: "float", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_type_local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    gps_latitude = table.Column<float>(type: "real", nullable: true),
                    gps_longitude = table.Column<float>(type: "real", nullable: true),
                    gps_accuracy_in_meters = table.Column<float>(type: "real", nullable: true),
                    warranty_in_month = table.Column<float>(type: "real", nullable: true),
                    transfer = table.Column<bool>(type: "bit", nullable: true),
                    payee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    labels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    envelope_id = table.Column<long>(type: "bigint", nullable: true),
                    custom_category = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    created_by_user_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by_user_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budgetbaker_wallet_import", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budgetbaker_wallet_import");
        }
    }
}
