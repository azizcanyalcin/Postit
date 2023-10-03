using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostitDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "User");
        }
    }
}
