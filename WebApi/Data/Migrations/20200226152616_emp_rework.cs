using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class emp_rework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonuses_Employees_EmployeeID",
                table: "Bonuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Candidates_CandidateID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_FormerEmployees_FormerEmployeeID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Employees_EmployeeID",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Employees_EmployeeID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Workplaces_WorkplaceID",
                table: "Specialties");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Employees_EmployeeID",
                table: "Vacations");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DrivingLicenceNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FamilyStatus",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HealthInsuranceCompany",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCardNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfTheBank",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfChildren",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "Type",
                table: "Specialties",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Bonuses_Employees_EmployeeID",
                table: "Bonuses",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Candidates_CandidateID",
                table: "Documents",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_FormerEmployees_FormerEmployeeID",
                table: "Documents",
                column: "FormerEmployeeID",
                principalTable: "FormerEmployees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Employees_EmployeeID",
                table: "Equipment",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Employees_EmployeeID",
                table: "Evaluations",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Workplaces_WorkplaceID",
                table: "Specialties",
                column: "WorkplaceID",
                principalTable: "Workplaces",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Employees_EmployeeID",
                table: "Vacations",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonuses_Employees_EmployeeID",
                table: "Bonuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Candidates_CandidateID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_FormerEmployees_FormerEmployeeID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Employees_EmployeeID",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Employees_EmployeeID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Workplaces_WorkplaceID",
                table: "Specialties");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Employees_EmployeeID",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DrivingLicenceNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FamilyStatus",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HealthInsuranceCompany",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdCardNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NameOfTheBank",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Specialties",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddForeignKey(
                name: "FK_Bonuses_Employees_EmployeeID",
                table: "Bonuses",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Candidates_CandidateID",
                table: "Documents",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_FormerEmployees_FormerEmployeeID",
                table: "Documents",
                column: "FormerEmployeeID",
                principalTable: "FormerEmployees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Employees_EmployeeID",
                table: "Equipment",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Employees_EmployeeID",
                table: "Evaluations",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Workplaces_WorkplaceID",
                table: "Specialties",
                column: "WorkplaceID",
                principalTable: "Workplaces",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Employees_EmployeeID",
                table: "Vacations",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
