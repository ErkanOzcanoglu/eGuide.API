using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class update_station_model_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StationModelId",
                table: "StationSockets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StationModelId",
                table: "StationSockets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
