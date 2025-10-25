using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Migrations
{
    /// <inheritdoc />
    public partial class CreateHosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hosts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    salutation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    given_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    family_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hosts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events_hosts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    host_id = table.Column<Guid>(type: "uuid", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events_hosts", x => x.id);
                    table.ForeignKey(
                        name: "fk_events_hosts_events_event_id",
                        column: x => x.event_id,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_events_hosts_hosts_host_id",
                        column: x => x.host_id,
                        principalTable: "hosts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_events_hosts_event_id_host_id",
                table: "events_hosts",
                columns: new[] { "event_id", "host_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_events_hosts_event_id_position",
                table: "events_hosts",
                columns: new[] { "event_id", "position" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_events_hosts_host_id",
                table: "events_hosts",
                column: "host_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events_hosts");

            migrationBuilder.DropTable(
                name: "hosts");
        }
    }
}
