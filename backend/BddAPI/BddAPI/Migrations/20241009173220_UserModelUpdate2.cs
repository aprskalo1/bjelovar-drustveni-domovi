using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BddAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserModelUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OIB",
                table: "Users",
                newName: "Oib");

            migrationBuilder.RenameColumn(
                name: "IBAN",
                table: "Users",
                newName: "Iban");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Oib",
                table: "Users",
                newName: "OIB");

            migrationBuilder.RenameColumn(
                name: "Iban",
                table: "Users",
                newName: "IBAN");
        }
    }
}
