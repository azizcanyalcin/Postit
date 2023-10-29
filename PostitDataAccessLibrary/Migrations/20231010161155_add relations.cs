using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostitDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class addrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Note",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Note_CreatedById",
                table: "Note",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_User_CreatedById",
                table: "Note",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_User_CreatedById",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_CreatedById",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Note");
        }
    }
}
