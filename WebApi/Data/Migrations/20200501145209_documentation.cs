using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class documentation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employees_EmployeeID",
                table: "Documents");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Employees_EmployeeID",
                table: "Documents",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employees_EmployeeID",
                table: "Documents");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Employees_EmployeeID",
                table: "Documents",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
