using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MorgueTrackerMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Employees_InEmployeeID",
                table: "Releases");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Employees_OutEmployeeID",
                table: "Releases");

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

            migrationBuilder.CreateIndex(
                name: "IX_Releases_EmployeeID",
                table: "Releases",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_EmployeeID1",
                table: "Releases",
                column: "EmployeeID1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "EmployeeID1",
                table: "Releases");

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Employees_InEmployeeID",
                table: "Releases",
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
    }
}
