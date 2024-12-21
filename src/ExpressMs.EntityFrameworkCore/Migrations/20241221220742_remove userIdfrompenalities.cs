using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class removeuserIdfrompenalities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExPenalities_AbpUsers_UsersId",
                table: "ExPenalities");

            migrationBuilder.DropIndex(
                name: "IX_ExPenalities_UsersId",
                table: "ExPenalities");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ExPenalities");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ExPenalities",
                newName: "AbpUsers");

            migrationBuilder.CreateIndex(
                name: "IX_ExPenalities_AbpUsers",
                table: "ExPenalities",
                column: "AbpUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ExPenalities_AbpUsers_AbpUsers",
                table: "ExPenalities",
                column: "AbpUsers",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExPenalities_AbpUsers_AbpUsers",
                table: "ExPenalities");

            migrationBuilder.DropIndex(
                name: "IX_ExPenalities_AbpUsers",
                table: "ExPenalities");

            migrationBuilder.RenameColumn(
                name: "AbpUsers",
                table: "ExPenalities",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "ExPenalities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExPenalities_UsersId",
                table: "ExPenalities",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExPenalities_AbpUsers_UsersId",
                table: "ExPenalities",
                column: "UsersId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}
