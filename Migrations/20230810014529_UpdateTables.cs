using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MorgueTrackerMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Employees_EmployeeID",
                table: "Releases");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Employees_EmployeeID1",
                table: "Releases");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Employees_InEmployeeID",
                table: "Releases");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Employees_OutEmployeeID",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Releases_EmployeeID",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Releases_EmployeeID1",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Releases_InEmployeeID",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "EmployeeID1",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "InEmployeeID",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "PickedUpDate",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InEmployeeID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InEmployeeID",
                table: "Patients",
                column: "InEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Employees_InEmployeeID",
                table: "Patients",
                column: "InEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Employees_OutEmployeeID",
                table: "Releases",
                column: "OutEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Employees_InEmployeeID",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Employees_OutEmployeeID",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Patients_InEmployeeID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "InEmployeeID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employees");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Releases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Releases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID1",
                table: "Releases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InEmployeeID",
                table: "Releases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickedUpDate",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_EmployeeID",
                table: "Releases",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_EmployeeID1",
                table: "Releases",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_InEmployeeID",
                table: "Releases",
                column: "InEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Employees_EmployeeID",
                table: "Releases",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Employees_EmployeeID1",
                table: "Releases",
                column: "EmployeeID1",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Employees_InEmployeeID",
                table: "Releases",
                column: "InEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Employees_OutEmployeeID",
                table: "Releases",
                column: "OutEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
