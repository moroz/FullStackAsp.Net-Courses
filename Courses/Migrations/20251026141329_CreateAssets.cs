using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Migrations
{
    /// <inheritdoc />
    public partial class CreateAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "profile_picture_id",
                table: "hosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "assets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    object_key = table.Column<string>(type: "text", nullable: false),
                    original_filename = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assets", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_hosts_profile_picture_id",
                table: "hosts",
                column: "profile_picture_id");

            migrationBuilder.AddForeignKey(
                name: "fk_hosts_assets_profile_picture_id",
                table: "hosts",
                column: "profile_picture_id",
                principalTable: "assets",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_hosts_assets_profile_picture_id",
                table: "hosts");

            migrationBuilder.DropTable(
                name: "assets");

            migrationBuilder.DropIndex(
                name: "ix_hosts_profile_picture_id",
                table: "hosts");

            migrationBuilder.DropColumn(
                name: "profile_picture_id",
                table: "hosts");
        }
    }
}
