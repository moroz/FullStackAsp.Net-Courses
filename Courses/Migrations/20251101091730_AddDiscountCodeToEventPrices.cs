using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountCodeToEventPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "discount_code",
                table: "event_prices",
                type: "citext",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_event_prices_discount_code_event_id",
                table: "event_prices",
                columns: new[] { "discount_code", "event_id" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "event_price_discount_code_check",
                table: "event_prices",
                sql: "(discount_code is null) = (rule_type != 'discount_code')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_event_prices_discount_code_event_id",
                table: "event_prices");

            migrationBuilder.DropCheckConstraint(
                name: "event_price_discount_code_check",
                table: "event_prices");

            migrationBuilder.DropColumn(
                name: "discount_code",
                table: "event_prices");
        }
    }
}
