using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BddAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("7a64bde5-8705-4ad5-8d69-1aadd2108a89"), "Administrator role with full access", "Superuser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7a64bde5-8705-4ad5-8d69-1aadd2108a89"));
        }
    }
}
