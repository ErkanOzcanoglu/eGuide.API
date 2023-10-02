using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class initialV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityStationProfile");

            migrationBuilder.DropTable(
                name: "SocketStationModel");

            migrationBuilder.AddColumn<Guid>(
                name: "StationModelId",
                table: "Socket",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StationFacility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationFacility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationFacility_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationFacility_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationSockets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationSockets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationSockets_Socket_SocketId",
                        column: x => x.SocketId,
                        principalTable: "Socket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationSockets_StationModel_StationModelId",
                        column: x => x.StationModelId,
                        principalTable: "StationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Socket_StationModelId",
                table: "Socket",
                column: "StationModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StationFacility_FacilityId",
                table: "StationFacility",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_StationFacility_StationId",
                table: "StationFacility",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_StationSockets_SocketId",
                table: "StationSockets",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_StationSockets_StationModelId",
                table: "StationSockets",
                column: "StationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socket_StationModel_StationModelId",
                table: "Socket",
                column: "StationModelId",
                principalTable: "StationModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socket_StationModel_StationModelId",
                table: "Socket");

            migrationBuilder.DropTable(
                name: "StationFacility");

            migrationBuilder.DropTable(
                name: "StationSockets");

            migrationBuilder.DropIndex(
                name: "IX_Socket_StationModelId",
                table: "Socket");

            migrationBuilder.DropColumn(
                name: "StationModelId",
                table: "Socket");

            migrationBuilder.CreateTable(
                name: "FacilityStationProfile",
                columns: table => new
                {
                    FacilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityStationProfile", x => new { x.FacilitiesId, x.StationsId });
                    table.ForeignKey(
                        name: "FK_FacilityStationProfile_Facility_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityStationProfile_Station_StationsId",
                        column: x => x.StationsId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocketStationModel",
                columns: table => new
                {
                    SocketsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationModelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocketStationModel", x => new { x.SocketsId, x.StationModelsId });
                    table.ForeignKey(
                        name: "FK_SocketStationModel_Socket_SocketsId",
                        column: x => x.SocketsId,
                        principalTable: "Socket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocketStationModel_StationModel_StationModelsId",
                        column: x => x.StationModelsId,
                        principalTable: "StationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityStationProfile_StationsId",
                table: "FacilityStationProfile",
                column: "StationsId");

            migrationBuilder.CreateIndex(
                name: "IX_SocketStationModel_StationModelsId",
                table: "SocketStationModel",
                column: "StationModelsId");
        }
    }
}
