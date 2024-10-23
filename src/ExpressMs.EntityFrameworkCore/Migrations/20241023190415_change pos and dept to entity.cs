using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class changeposanddepttoentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "ExPositions");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ExDepartments");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "ExDepartments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "ExPositions",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ExPositions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "ExPositions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "ExPositions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ExPositions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "ExPositions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExPositions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ExPositions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "ExPositions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "ExDepartments",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ExDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "ExDepartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "ExDepartments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ExDepartments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "ExDepartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExDepartments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ExDepartments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "ExDepartments",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
