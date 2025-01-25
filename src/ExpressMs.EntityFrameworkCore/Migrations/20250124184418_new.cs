using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExEmployeesData_ExRecruitmentApplications_ApplicationId",
                table: "ExEmployeesData");

            migrationBuilder.DropForeignKey(
                name: "FK_ExRequests_AbpUsers_RequesterId",
                table: "ExRequests");

            migrationBuilder.RenameColumn(
                name: "Current",
                table: "ExRequestStates",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExRequestStates_UserId",
                table: "ExRequestStates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExEmployeesData_PositionId",
                table: "ExEmployeesData",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExEmployeesData_ExPositions_PositionId",
                table: "ExEmployeesData",
                column: "PositionId",
                principalTable: "ExPositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExEmployeesData_ExRecruitmentApplications_ApplicationId",
                table: "ExEmployeesData",
                column: "ApplicationId",
                principalTable: "ExRecruitmentApplications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExRequests_AbpUsers_RequesterId",
                table: "ExRequests",
                column: "RequesterId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExRequestStates_AbpUsers_UserId",
                table: "ExRequestStates",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExEmployeesData_ExPositions_PositionId",
                table: "ExEmployeesData");

            migrationBuilder.DropForeignKey(
                name: "FK_ExEmployeesData_ExRecruitmentApplications_ApplicationId",
                table: "ExEmployeesData");

            migrationBuilder.DropForeignKey(
                name: "FK_ExRequests_AbpUsers_RequesterId",
                table: "ExRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ExRequestStates_AbpUsers_UserId",
                table: "ExRequestStates");

            migrationBuilder.DropIndex(
                name: "IX_ExRequestStates_UserId",
                table: "ExRequestStates");

            migrationBuilder.DropIndex(
                name: "IX_ExEmployeesData_PositionId",
                table: "ExEmployeesData");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ExRequestStates",
                newName: "Current");

            migrationBuilder.AddForeignKey(
                name: "FK_ExEmployeesData_ExRecruitmentApplications_ApplicationId",
                table: "ExEmployeesData",
                column: "ApplicationId",
                principalTable: "ExRecruitmentApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExRequests_AbpUsers_RequesterId",
                table: "ExRequests",
                column: "RequesterId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
