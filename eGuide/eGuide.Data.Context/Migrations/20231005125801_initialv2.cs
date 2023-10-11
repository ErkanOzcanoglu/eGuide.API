using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class initialv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socket_StationModel_StationModelId",
                table: "Socket");

            migrationBuilder.DropIndex(
                name: "IX_Socket_StationModelId",
                table: "Socket");

            migrationBuilder.DropColumn(
                name: "StationModelId",
                table: "Socket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StationModelId",
                table: "Socket",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socket_StationModelId",
                table: "Socket",
                column: "StationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socket_StationModel_StationModelId",
                table: "Socket",
                column: "StationModelId",
                principalTable: "StationModel",
                principalColumn: "Id");
        }
    }
}
