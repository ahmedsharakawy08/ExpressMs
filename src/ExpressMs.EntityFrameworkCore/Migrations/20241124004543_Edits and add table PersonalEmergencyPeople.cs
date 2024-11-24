using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class EditsandaddtablePersonalEmergencyPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExInsuranceData_ApplicationId",
                table: "ExInsuranceData");

            migrationBuilder.DropColumn(
                name: "DeflictEndDate",
                table: "ExInsuranceData");

            migrationBuilder.AddColumn<double>(
                name: "DeflictPercent",
                table: "ExInsuranceData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Decision",
                table: "ExApplicationDepartmentEvaluations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExPersonalEmergencyPeople",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExPersonalEmergencyPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExPersonalEmergencyPeople_ExRecruitmentApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "ExRecruitmentApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExInsuranceData_ApplicationId",
                table: "ExInsuranceData",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExPersonalEmergencyPeople_ApplicationId",
                table: "ExPersonalEmergencyPeople",
                column: "ApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExPersonalEmergencyPeople");

            migrationBuilder.DropIndex(
                name: "IX_ExInsuranceData_ApplicationId",
                table: "ExInsuranceData");

            migrationBuilder.DropColumn(
                name: "DeflictPercent",
                table: "ExInsuranceData");

            migrationBuilder.DropColumn(
                name: "Decision",
                table: "ExApplicationDepartmentEvaluations");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeflictEndDate",
                table: "ExInsuranceData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ExInsuranceData_ApplicationId",
                table: "ExInsuranceData",
                column: "ApplicationId");
        }
    }
}
