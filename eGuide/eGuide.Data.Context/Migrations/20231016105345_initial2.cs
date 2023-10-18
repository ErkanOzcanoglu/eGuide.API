using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationSockets_Station_StationProfileId",
                table: "StationSockets");

            migrationBuilder.DropIndex(
                name: "IX_StationSockets_StationProfileId",
                table: "StationSockets");

            migrationBuilder.DropColumn(
                name: "StationProfileId",
                table: "StationSockets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StationProfileId",
                table: "StationSockets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StationSockets_StationProfileId",
                table: "StationSockets",
                column: "StationProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_StationSockets_Station_StationProfileId",
                table: "StationSockets",
                column: "StationProfileId",
                principalTable: "Station",
                principalColumn: "Id");
        }
    }
}
