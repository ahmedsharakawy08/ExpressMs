using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class Citiesandgovernoraterelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExCities_ExGovernorates_GovernorateId1",
                table: "ExCities");

            migrationBuilder.DropIndex(
                name: "IX_ExCities_GovernorateId1",
                table: "ExCities");

            migrationBuilder.DropColumn(
                name: "GovernorateId1",
                table: "ExCities");

            migrationBuilder.AlterColumn<int>(
                name: "GovernorateId",
                table: "ExCities",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ExCities_GovernorateId",
                table: "ExCities",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExCities_ExGovernorates_GovernorateId",
                table: "ExCities",
                column: "GovernorateId",
                principalTable: "ExGovernorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExCities_ExGovernorates_GovernorateId",
                table: "ExCities");

            migrationBuilder.DropIndex(
                name: "IX_ExCities_GovernorateId",
                table: "ExCities");

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernorateId",
                table: "ExCities",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId1",
                table: "ExCities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExCities_GovernorateId1",
                table: "ExCities",
                column: "GovernorateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExCities_ExGovernorates_GovernorateId1",
                table: "ExCities",
                column: "GovernorateId1",
                principalTable: "ExGovernorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
