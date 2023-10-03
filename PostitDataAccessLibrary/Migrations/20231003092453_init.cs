using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostitDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Fullname = table.Column<string>(type: "char varying", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "char varying", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "char varying", maxLength: 320, nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
