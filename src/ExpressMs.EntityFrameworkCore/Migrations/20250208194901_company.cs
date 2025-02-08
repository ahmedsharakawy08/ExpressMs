using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "ExDepartments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ExCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExCompanies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExDepartments_CompanyId",
                table: "ExDepartments",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExDepartments_ExCompanies_CompanyId",
                table: "ExDepartments",
                column: "CompanyId",
                principalTable: "ExCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExDepartments_ExCompanies_CompanyId",
                table: "ExDepartments");

            migrationBuilder.DropTable(
                name: "ExCompanies");

            migrationBuilder.DropIndex(
                name: "IX_ExDepartments_CompanyId",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ExDepartments");
        }
    }
}
