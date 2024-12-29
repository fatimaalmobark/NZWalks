using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class initialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthInKm = table.Column<double>(type: "float", nullable: false),
                    WalkImageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifficaltyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Difficulties_DifficaltyId",
                        column: x => x.DifficaltyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("98526a56-dbbf-4b86-b9a2-dd2b526f0fc1"), "MIDUEM" },
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

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficaltyId",
                table: "Walks",
                column: "DifficaltyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
