﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eGuide.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class inital_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Latitude", "Longitude", "Name", "StationModelId", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4837ff86-6796-44b9-bbb0-f02ad670911d"), "Address1", new DateTime(2023, 10, 24, 13, 18, 25, 152, DateTimeKind.Local).AddTicks(2011), null, "39.28490810034864", "32.83302000000003", "Name1", new Guid("fcd65466-6362-4ae3-bc9a-092c7aaeaeaa"), 1, null },
                    { new Guid("f572ff7b-cdb6-41a2-bb21-75641a631d3c"), "Address2", new DateTime(2023, 10, 24, 13, 18, 25, 152, DateTimeKind.Local).AddTicks(2022), null, "39.28490810034864", "32.83302000000003", "Name2", new Guid("4057a7c1-bab2-4c6d-96ea-dfea4a2448a8"), 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: new Guid("4837ff86-6796-44b9-bbb0-f02ad670911d"));

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: new Guid("f572ff7b-cdb6-41a2-bb21-75641a631d3c"));
        }
    }
}
