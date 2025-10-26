using Courses.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Migrations
{
    /// <inheritdoc />
    public partial class AddEventTypeToEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:event_type", "seminar,webinar")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .OldAnnotation("Npgsql:PostgresExtension:citext", ",,");

            migrationBuilder.AddColumn<EventType>(
                name: "event_type",
                table: "events",
                type: "event_type",
                nullable: false,
                defaultValue: EventType.Seminar);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "event_type",
                table: "events");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .OldAnnotation("Npgsql:Enum:event_type", "seminar,webinar")
                .OldAnnotation("Npgsql:PostgresExtension:citext", ",,");
        }
    }
}
