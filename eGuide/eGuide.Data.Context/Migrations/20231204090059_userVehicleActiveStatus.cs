using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class userVehicleActiveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "ActiveStatus",
                table: "UserVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "UserVehicle");

            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
