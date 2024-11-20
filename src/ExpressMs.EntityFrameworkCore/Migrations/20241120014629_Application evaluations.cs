using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class Applicationevaluations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExApplicationDepartmentEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weakness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExApplicationDepartmentEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExApplicationDepartmentEvaluations_ExRecruitmentApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "ExRecruitmentApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExApplicationPersonalEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExApplicationPersonalEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExApplicationPersonalEvaluations_ExRecruitmentApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "ExRecruitmentApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExApplicationDepartmentEvaluations_ApplicationId",
                table: "ExApplicationDepartmentEvaluations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExApplicationPersonalEvaluations_ApplicationId",
                table: "ExApplicationPersonalEvaluations",
                column: "ApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExApplicationDepartmentEvaluations");

            migrationBuilder.DropTable(
                name: "ExApplicationPersonalEvaluations");
        }
    }
}
