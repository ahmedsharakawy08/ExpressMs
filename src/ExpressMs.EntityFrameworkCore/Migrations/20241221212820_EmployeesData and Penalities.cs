using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressMs.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesDataandPenalities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ExPositions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ExDepartments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "ExEmployeesData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullEnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsappPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    FormType = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MartialStatus = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectManager = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KidsNumber = table.Column<int>(type: "int", nullable: false),
                    BasicSalary = table.Column<double>(type: "float", nullable: false),
                    HouseAllowance = table.Column<double>(type: "float", nullable: false),
                    TransportationAllowance = table.Column<double>(type: "float", nullable: false),
                    OtherAllowances = table.Column<double>(type: "float", nullable: false),
                    TotalSalary = table.Column<double>(type: "float", nullable: false),
                    InsuranceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscribedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscribtionSalary = table.Column<double>(type: "float", nullable: false),
                    GrossSalary = table.Column<double>(type: "float", nullable: false),
                    RelationToBussinessOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeflictStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeflictPercent = table.Column<double>(type: "float", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExEmployeesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExEmployeesData_AbpUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExEmployeesData_ExRecruitmentApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "ExRecruitmentApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExPenalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfDays = table.Column<double>(type: "float", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExPenalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExPenalities_AbpUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExEmployeesData_ApplicationId",
                table: "ExEmployeesData",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExEmployeesData_UsersId",
                table: "ExEmployeesData",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ExPenalities_UsersId",
                table: "ExPenalities",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExEmployeesData");

            migrationBuilder.DropTable(
                name: "ExPenalities");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ExPositions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ExDepartments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");
        }
    }
}
