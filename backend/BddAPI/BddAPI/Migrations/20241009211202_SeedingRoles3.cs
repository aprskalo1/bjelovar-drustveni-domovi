using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BddAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7a64bde5-8705-4ad5-8d69-1aadd2108a89"),
                column: "Description",
                value: "Superuser role with full access");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9b1f6c4-dce5-4b26-88b1-29b9b29f5d2b"),
                column: "Description",
                value: "Administrator role with access to most of the features");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7a64bde5-8705-4ad5-8d69-1aadd2108a89"),
                column: "Description",
                value: "Administrator role with full access");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9b1f6c4-dce5-4b26-88b1-29b9b29f5d2b"),
                column: "Description",
                value: "Administrator role with full access");
        }
    }
}
