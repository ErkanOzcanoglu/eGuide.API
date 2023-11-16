using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class vehicleFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Connector_ConnectorId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConnectorId",
                table: "Vehicle",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Connector_ConnectorId",
                table: "Vehicle",
                column: "ConnectorId",
                principalTable: "Connector",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Connector_ConnectorId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConnectorId",
                table: "Vehicle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Connector_ConnectorId",
                table: "Vehicle",
                column: "ConnectorId",
                principalTable: "Connector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
