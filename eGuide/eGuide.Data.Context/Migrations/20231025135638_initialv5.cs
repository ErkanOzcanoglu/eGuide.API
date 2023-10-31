using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class initialv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: new Guid("4837ff86-6796-44b9-bbb0-f02ad670911d"));

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: new Guid("f572ff7b-cdb6-41a2-bb21-75641a631d3c"));

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

            migrationBuilder.CreateTable(
                name: "StationInformationDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Current = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voltage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectorType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationInformationDto", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationSocket_Socket_SocketId",
                table: "StationSocket");

            migrationBuilder.DropForeignKey(
                name: "FK_StationSocket_StationModels_StationModelId",
                table: "StationSocket");

            migrationBuilder.DropTable(
                name: "StationInformationDto");

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

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Latitude", "Longitude", "Name", "StationModelId", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4837ff86-6796-44b9-bbb0-f02ad670911d"), "Address1", new DateTime(2023, 10, 24, 13, 18, 25, 152, DateTimeKind.Local).AddTicks(2011), null, "39.28490810034864", "32.83302000000003", "Name1", new Guid("fcd65466-6362-4ae3-bc9a-092c7aaeaeaa"), 1, null },
                    { new Guid("f572ff7b-cdb6-41a2-bb21-75641a631d3c"), "Address2", new DateTime(2023, 10, 24, 13, 18, 25, 152, DateTimeKind.Local).AddTicks(2022), null, "39.28490810034864", "32.83302000000003", "Name2", new Guid("4057a7c1-bab2-4c6d-96ea-dfea4a2448a8"), 1, null }
                });

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
    }
}
