using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class adduserIdtopenalities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExPenalities_AbpUsers_AbpUsers",
                table: "ExPenalities");

            migrationBuilder.RenameColumn(
                name: "AbpUsers",
                table: "ExPenalities",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExPenalities_AbpUsers",
                table: "ExPenalities",
                newName: "IX_ExPenalities_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExPenalities_AbpUsers_UserId",
                table: "ExPenalities",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExPenalities_AbpUsers_UserId",
                table: "ExPenalities");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ExPenalities",
                newName: "AbpUsers");

            migrationBuilder.RenameIndex(
                name: "IX_ExPenalities_UserId",
                table: "ExPenalities",
                newName: "IX_ExPenalities_AbpUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ExPenalities_AbpUsers_AbpUsers",
                table: "ExPenalities",
                column: "AbpUsers",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
