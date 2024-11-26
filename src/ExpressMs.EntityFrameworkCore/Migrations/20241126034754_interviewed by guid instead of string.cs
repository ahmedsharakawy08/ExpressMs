using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class interviewedbyguidinsteadofstring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "InterviewedBy",
                table: "ExApplicationDepartmentEvaluations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InterviewedBy",
                table: "ExApplicationDepartmentEvaluations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
