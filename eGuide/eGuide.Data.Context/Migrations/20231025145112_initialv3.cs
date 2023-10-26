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
                name: "FK_StationSocket_Socket_SocketId",
                table: "StationSocket");

            migrationBuilder.DropForeignKey(
                name: "FK_StationSocket_StationModels_StationModelId",
                table: "StationSocket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationSocket",
                table: "StationSocket");

            migrationBuilder.RenameTable(
                name: "StationSocket",
                newName: "StationSockets");

            migrationBuilder.RenameIndex(
                name: "IX_StationSocket_StationModelId",
                table: "StationSockets",
                newName: "IX_StationSockets_StationModelId");

            migrationBuilder.RenameIndex(
                name: "IX_StationSocket_SocketId",
                table: "StationSockets",
                newName: "IX_StationSockets_SocketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationSockets",
                table: "StationSockets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StationSockets_Socket_SocketId",
                table: "StationSockets",
                column: "SocketId",
                principalTable: "Socket",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationSockets_Socket_SocketId",
                table: "StationSockets");

            migrationBuilder.DropForeignKey(
                name: "FK_StationSockets_StationModels_StationModelId",
                table: "StationSockets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationSockets",
                table: "StationSockets");

            migrationBuilder.RenameTable(
                name: "StationSockets",
                newName: "StationSocket");

            migrationBuilder.RenameIndex(
                name: "IX_StationSockets_StationModelId",
                table: "StationSocket",
                newName: "IX_StationSocket_StationModelId");

            migrationBuilder.RenameIndex(
                name: "IX_StationSockets_SocketId",
                table: "StationSocket",
                newName: "IX_StationSocket_SocketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationSocket",
                table: "StationSocket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StationSocket_Socket_SocketId",
                table: "StationSocket",
                column: "SocketId",
                principalTable: "Socket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationSocket_StationModels_StationModelId",
                table: "StationSocket",
                column: "StationModelId",
                principalTable: "StationModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
