using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class NZWalksDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_difficalties_DifficaltyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Walks",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_difficalties",
                table: "difficalties");

            migrationBuilder.RenameTable(
                name: "Walks",
                newName: "walks");

            migrationBuilder.RenameTable(
                name: "difficalties",
                newName: "Difficulties");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_RegionId",
                table: "walks",
                newName: "IX_walks_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_DifficaltyId",
                table: "walks",
                newName: "IX_walks_DifficaltyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_walks",
                table: "walks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_walks_Difficulties_DifficaltyId",
                table: "walks",
                column: "DifficaltyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_walks_Regions_RegionId",
                table: "walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_walks_Difficulties_DifficaltyId",
                table: "walks");

            migrationBuilder.DropForeignKey(
                name: "FK_walks_Regions_RegionId",
                table: "walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_walks",
                table: "walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties");

            migrationBuilder.RenameTable(
                name: "walks",
                newName: "Walks");

            migrationBuilder.RenameTable(
                name: "Difficulties",
                newName: "difficalties");

            migrationBuilder.RenameIndex(
                name: "IX_walks_RegionId",
                table: "Walks",
                newName: "IX_Walks_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_walks_DifficaltyId",
                table: "Walks",
                newName: "IX_Walks_DifficaltyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Walks",
                table: "Walks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_difficalties",
                table: "difficalties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_difficalties_DifficaltyId",
                table: "Walks",
                column: "DifficaltyId",
                principalTable: "difficalties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
