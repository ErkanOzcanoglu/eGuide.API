using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class vehicleActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Station_StationId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_StationId",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StationProfileId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_StationProfileId",
                table: "Comment",
                column: "StationProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Station_StationProfileId",
                table: "Comment",
                column: "StationProfileId",
                principalTable: "Station",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Station_StationProfileId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_StationProfileId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "StationProfileId",
                table: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_StationId",
                table: "Comment",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Station_StationId",
                table: "Comment",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
