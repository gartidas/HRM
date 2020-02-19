using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class AppUserDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_IdentityUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Workers_Users_IdentityUserId",
                table: "HR_Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceLeaders_Users_IdentityUserId",
                table: "WorkPlaceLeaders");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "WorkPlaceLeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "HR_Workers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_IdentityUserId",
                table: "Employees",
                column: "IdentityUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Workers_Users_IdentityUserId",
                table: "HR_Workers",
                column: "IdentityUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceLeaders_Users_IdentityUserId",
                table: "WorkPlaceLeaders",
                column: "IdentityUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_IdentityUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Workers_Users_IdentityUserId",
                table: "HR_Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceLeaders_Users_IdentityUserId",
                table: "WorkPlaceLeaders");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "WorkPlaceLeaders",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "HR_Workers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_IdentityUserId",
                table: "Employees",
                column: "IdentityUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Workers_Users_IdentityUserId",
                table: "HR_Workers",
                column: "IdentityUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceLeaders_Users_IdentityUserId",
                table: "WorkPlaceLeaders",
                column: "IdentityUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
