using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class vehicleAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Connector_ConnectorId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ConnectorId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ConnectorId",
                table: "Vehicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConnectorId",
                table: "Vehicle",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ConnectorId",
                table: "Vehicle",
                column: "ConnectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Connector_ConnectorId",
                table: "Vehicle",
                column: "ConnectorId",
                principalTable: "Connector",
                principalColumn: "Id");
        }
    }
}
