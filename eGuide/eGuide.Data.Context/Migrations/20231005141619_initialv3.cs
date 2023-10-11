using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class initialv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Station_StationModel_StationModelId",
                table: "Station");

            migrationBuilder.RenameColumn(
                name: "StationModelId",
                table: "Station",
                newName: "StationSocketsId");

            migrationBuilder.RenameIndex(
                name: "IX_Station_StationModelId",
                table: "Station",
                newName: "IX_Station_StationSocketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Station_StationSockets_StationSocketsId",
                table: "Station",
                column: "StationSocketsId",
                principalTable: "StationSockets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Station_StationSockets_StationSocketsId",
                table: "Station");

            migrationBuilder.RenameColumn(
                name: "StationSocketsId",
                table: "Station",
                newName: "StationModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Station_StationSocketsId",
                table: "Station",
                newName: "IX_Station_StationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Station_StationModel_StationModelId",
                table: "Station",
                column: "StationModelId",
                principalTable: "StationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
