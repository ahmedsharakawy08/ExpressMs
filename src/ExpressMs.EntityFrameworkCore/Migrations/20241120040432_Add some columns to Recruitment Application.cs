using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class AddsomecolumnstoRecruitmentApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualStartDate",
                table: "ExRecruitmentApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ContractPeriod",
                table: "ExRecruitmentApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateToRecieveDocs",
                table: "ExRecruitmentApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DirectManager",
                table: "ExRecruitmentApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "KidsNumber",
                table: "ExRecruitmentApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NationalIdDate",
                table: "ExRecruitmentApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalIdPlace",
                table: "ExRecruitmentApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "ExRecruitmentApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SafetyResult",
                table: "ExRecruitmentApplications",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualStartDate",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "ContractPeriod",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "DateToRecieveDocs",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "DirectManager",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "KidsNumber",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "NationalIdDate",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "NationalIdPlace",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "ExRecruitmentApplications");

            migrationBuilder.DropColumn(
                name: "SafetyResult",
                table: "ExRecruitmentApplications");
        }
    }
}
