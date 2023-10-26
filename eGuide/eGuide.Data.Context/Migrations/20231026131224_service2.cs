using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class service2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Station_StationModels_StationModelId",
                table: "Station");

            migrationBuilder.DropForeignKey(
                name: "FK_StationSockets_StationModels_StationModelId",
                table: "StationSockets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationModels",
                table: "StationModels");

            migrationBuilder.RenameTable(
                name: "StationModels",
                newName: "StationModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationModel",
                table: "StationModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Station_StationModel_StationModelId",
                table: "Station",
                column: "StationModelId",
                principalTable: "StationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationSockets_StationModel_StationModelId",
                table: "StationSockets",
                column: "StationModelId",
                principalTable: "StationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Station_StationModel_StationModelId",
                table: "Station");

            migrationBuilder.DropForeignKey(
                name: "FK_StationSockets_StationModel_StationModelId",
                table: "StationSockets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationModel",
                table: "StationModel");

            migrationBuilder.RenameTable(
                name: "StationModel",
                newName: "StationModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationModels",
                table: "StationModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Station_StationModels_StationModelId",
                table: "Station",
                column: "StationModelId",
                principalTable: "StationModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationSockets_StationModels_StationModelId",
                table: "StationSockets",
                column: "StationModelId",
                principalTable: "StationModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
