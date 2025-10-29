using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Migrations
{
    /// <inheritdoc />
    public partial class CreateVenues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "venue",
                table: "events");

            migrationBuilder.AddColumn<Guid>(
                name: "venue_id",
                table: "events",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "venues",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name_en = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name_pl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    street = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    city_en = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    city_pl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    postal_code = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_venues", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_events_venue_id",
                table: "events",
                column: "venue_id");

            migrationBuilder.AddForeignKey(
                name: "fk_events_venues_venue_id",
                table: "events",
                column: "venue_id",
                principalTable: "venues",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_events_venues_venue_id",
                table: "events");

            migrationBuilder.DropTable(
                name: "venues");

            migrationBuilder.DropIndex(
                name: "ix_events_venue_id",
                table: "events");

            migrationBuilder.DropColumn(
                name: "venue_id",
                table: "events");

            migrationBuilder.AddColumn<string>(
                name: "venue",
                table: "events",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
