using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdatafromDifficaltyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bf49e8e0-f19d-49f3-9580-a613e35b4c3d"), "MIDUEM" },
                    { new Guid("db00865a-39a2-4507-9481-ba5284e5e9d8"), "EASY" },
                    { new Guid("e0db330e-fabe-4fe0-bc3d-c998ef244f14"), "HARD" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageId" },
                values: new object[,]
                {
                    { new Guid("3da2c37e-2676-4c96-8a03-282e0d784fee"), "550", "OMDURMAN", "SOME _IMAGE _FROM _OMDURMAN.png" },
                    { new Guid("7cadcee0-6547-4b1d-87b3-685c21662829"), "240", "BAHRI", "SOME _IMAGE _FROM_BAHRI.png" },
                    { new Guid("f24a5ff2-9650-4756-a141-b0d705d89235"), "249", "KHARTOUM", "SOME _IMAGE _FROM _KHARTOUM.png" },
                    { new Guid("f8bc4a64-7538-4b60-b38b-32b5986a6ca5"), "241", "HALFA", "SOME _IMAGE _FROM_HALFA.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("bf49e8e0-f19d-49f3-9580-a613e35b4c3d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("db00865a-39a2-4507-9481-ba5284e5e9d8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e0db330e-fabe-4fe0-bc3d-c998ef244f14"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3da2c37e-2676-4c96-8a03-282e0d784fee"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7cadcee0-6547-4b1d-87b3-685c21662829"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f24a5ff2-9650-4756-a141-b0d705d89235"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f8bc4a64-7538-4b60-b38b-32b5986a6ca5"));
        }
    }
}
