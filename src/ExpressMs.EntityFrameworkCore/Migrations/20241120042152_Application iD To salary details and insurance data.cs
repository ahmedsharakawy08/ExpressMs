using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationiDTosalarydetailsandinsurancedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "ExSalaryDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "ExInsuranceData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExSalaryDetails_ApplicationId",
                table: "ExSalaryDetails",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExInsuranceData_ApplicationId",
                table: "ExInsuranceData",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExInsuranceData_ExRecruitmentApplications_ApplicationId",
                table: "ExInsuranceData",
                column: "ApplicationId",
                principalTable: "ExRecruitmentApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExSalaryDetails_ExRecruitmentApplications_ApplicationId",
                table: "ExSalaryDetails",
                column: "ApplicationId",
                principalTable: "ExRecruitmentApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExInsuranceData_ExRecruitmentApplications_ApplicationId",
                table: "ExInsuranceData");

            migrationBuilder.DropForeignKey(
                name: "FK_ExSalaryDetails_ExRecruitmentApplications_ApplicationId",
                table: "ExSalaryDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExSalaryDetails_ApplicationId",
                table: "ExSalaryDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExInsuranceData_ApplicationId",
                table: "ExInsuranceData");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "ExSalaryDetails");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "ExInsuranceData");
        }
    }
}
