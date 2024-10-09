using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BddAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("c9b1f6c4-dce5-4b26-88b1-29b9b29f5d2b"), "Administrator role with full access", "Admin" },
                    { new Guid("de19b1a7-8dc3-49e2-b98f-9990a9f59118"), "Regular user role with limited access", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9b1f6c4-dce5-4b26-88b1-29b9b29f5d2b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("de19b1a7-8dc3-49e2-b98f-9990a9f59118"));
        }
    }
}
