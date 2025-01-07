using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class removeuserIdinemployeesdataduplicate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExEmployeesData_AbpUsers_UsersId",
                table: "ExEmployeesData");

            migrationBuilder.DropIndex(
                name: "IX_ExEmployeesData_UsersId",
                table: "ExEmployeesData");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ExEmployeesData");

            migrationBuilder.CreateIndex(
                name: "IX_ExEmployeesData_UserId",
                table: "ExEmployeesData",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExEmployeesData_AbpUsers_UserId",
                table: "ExEmployeesData",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExEmployeesData_AbpUsers_UserId",
                table: "ExEmployeesData");

            migrationBuilder.DropIndex(
                name: "IX_ExEmployeesData_UserId",
                table: "ExEmployeesData");

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "ExEmployeesData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExEmployeesData_UsersId",
                table: "ExEmployeesData",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExEmployeesData_AbpUsers_UsersId",
                table: "ExEmployeesData",
                column: "UsersId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
