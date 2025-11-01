using System;
using Courses.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Migrations
{
    /// <inheritdoc />
    public partial class CreateEventPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:event_type", "seminar,webinar")
                .Annotation("Npgsql:Enum:price_rule_type", "base,discount_code,early_bird")
                .Annotation("Npgsql:Enum:price_type", "discount_fixed,discount_percentage,fixed,percentage")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .OldAnnotation("Npgsql:Enum:event_type", "seminar,webinar")
                .OldAnnotation("Npgsql:PostgresExtension:citext", ",,");

            migrationBuilder.AddColumn<decimal>(
                name: "base_price_amount",
                table: "events",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "base_price_currency",
                table: "events",
                type: "character varying(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "event_prices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price_type = table.Column<PriceType>(type: "price_type", nullable: false),
                    rule_type = table.Column<PriceRuleType>(type: "price_rule_type", nullable: false),
                    price_amount = table.Column<decimal>(type: "numeric(20,8)", nullable: false),
                    price_currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    valid_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    valid_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event_prices", x => x.id);
                    table.CheckConstraint("event_price_early_bird_check", "rule_type != 'early_bird' or valid_until is not null");
                    table.ForeignKey(
                        name: "fk_event_prices_events_event_id",
                        column: x => x.event_id,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddCheckConstraint(
                name: "event_base_price_must_have_currency",
                table: "events",
                sql: "(base_price_amount is null) = (base_price_currency is null)");

            migrationBuilder.CreateIndex(
                name: "ix_event_prices_event_id",
                table: "event_prices",
                column: "event_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event_prices");

            migrationBuilder.DropCheckConstraint(
                name: "event_base_price_must_have_currency",
                table: "events");

            migrationBuilder.DropColumn(
                name: "base_price_amount",
                table: "events");

            migrationBuilder.DropColumn(
                name: "base_price_currency",
                table: "events");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:event_type", "seminar,webinar")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .OldAnnotation("Npgsql:Enum:event_type", "seminar,webinar")
                .OldAnnotation("Npgsql:Enum:price_rule_type", "base,discount_code,early_bird")
                .OldAnnotation("Npgsql:Enum:price_type", "discount_fixed,discount_percentage,fixed,percentage")
                .OldAnnotation("Npgsql:PostgresExtension:citext", ",,");
        }
    }
}
