using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class update_station_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationSockets_StationModel_StationModelId",
                table: "StationSockets");

            migrationBuilder.DropTable(
                name: "StationModel");

            migrationBuilder.DropIndex(
                name: "IX_StationSockets_StationModelId",
                table: "StationSockets");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StationSockets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "StationSockets");

            migrationBuilder.CreateTable(
                name: "StationModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StationSockets_StationModelId",
                table: "StationSockets",
                column: "StationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StationSockets_StationModel_StationModelId",
                table: "StationSockets",
                column: "StationModelId",
                principalTable: "StationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
