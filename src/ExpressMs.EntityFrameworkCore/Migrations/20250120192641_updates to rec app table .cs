using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class updatestorecapptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RequesterId",
                table: "ExRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "AnnualRecord",
                table: "ExRecruitmentApplications",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CasualRecord",
                table: "ExRecruitmentApplications",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ExRequests_RequesterId",
                table: "ExRequests",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExRequests_AbpUsers_RequesterId",
                table: "ExRequests",
                column: "RequesterId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExRequests_AbpUsers_RequesterId",
                table: "ExRequests");

            migrationBuilder.DropIndex(
                name: "IX_ExRequests_RequesterId",
                table: "ExRequests");

            migrationBuilder.DropColumn(
                name: "RequesterId",
                table: "ExRequests");

            migrationBuilder.DropColumn(
                name: "AnnualRecord",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "CasualRecord",
                table: "ExRecruitmentApplications");
        }
    }
}
