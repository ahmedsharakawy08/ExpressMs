using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class cityandgovernoraterelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GovernorateId",
                table: "ExCities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExCities_ExGovernorates_GovernorateId1",
                table: "ExCities");

            migrationBuilder.DropIndex(
                name: "IX_ExCities_GovernorateId1",
                table: "ExCities");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "ExCities");

            migrationBuilder.DropColumn(
                name: "GovernorateId1",
                table: "ExCities");
        }
    }
}
