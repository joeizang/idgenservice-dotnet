using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace idgenapi.Migrations
{
    /// <inheritdoc />
    public partial class InitApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "idsgenerated",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    servername = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    serverip = table.Column<string>(type: "TEXT", maxLength: 18, nullable: false),
                    ulidstring = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    uuidstring = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false),
                    createdon = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idsgenerated", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "idsgenerated");
        }
    }
}
