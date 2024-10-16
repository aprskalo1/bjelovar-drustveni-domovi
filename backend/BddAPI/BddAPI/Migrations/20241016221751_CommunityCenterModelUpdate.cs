using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BddAPI.Migrations
{
    /// <inheritdoc />
    public partial class CommunityCenterModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "CommunityCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "CommunityCenters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "CommunityCenters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "CommunityCenters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Price",
                table: "CommunityCenters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "CommunityCenters");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CommunityCenters");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CommunityCenters");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "CommunityCenters");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CommunityCenters");
        }
    }
}
