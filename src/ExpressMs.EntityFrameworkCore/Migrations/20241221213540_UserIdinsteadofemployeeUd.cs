using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class UserIdinsteadofemployeeUd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ExPenalities",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ExPenalities",
                newName: "EmployeeId");
        }
    }
}
