using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostitDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_User_CreatedById",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_CreatedById",
                table: "Note");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Note",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_UserId",
                table: "Note",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_User_UserId",
                table: "Note",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_User_UserId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_UserId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Note");

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
    }
}
