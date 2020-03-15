using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class joinfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCorporateEvent_CorporateEvents_CorporateEventID",
                table: "EmployeeCorporateEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCorporateEvent_Employees_EmployeeID",
                table: "EmployeeCorporateEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceLeaderCorporateEvent_CorporateEvents_CorporateEventID",
                table: "WorkPlaceLeaderCorporateEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceLeaderCorporateEvent_WorkPlaceLeaders_WorkPlaceLeaderID",
                table: "WorkPlaceLeaderCorporateEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkPlaceLeaderCorporateEvent",
                table: "WorkPlaceLeaderCorporateEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeCorporateEvent",
                table: "EmployeeCorporateEvent");

            migrationBuilder.RenameTable(
                name: "WorkPlaceLeaderCorporateEvent",
                newName: "WorkPlaceLeaderCorporateEvents");

            migrationBuilder.RenameTable(
                name: "EmployeeCorporateEvent",
                newName: "EmployeeCorporateEvents");

            migrationBuilder.RenameIndex(
                name: "IX_WorkPlaceLeaderCorporateEvent_WorkPlaceLeaderID",
                table: "WorkPlaceLeaderCorporateEvents",
                newName: "IX_WorkPlaceLeaderCorporateEvents_WorkPlaceLeaderID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCorporateEvent_EmployeeID",
                table: "EmployeeCorporateEvents",
                newName: "IX_EmployeeCorporateEvents_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkPlaceLeaderCorporateEvents",
                table: "WorkPlaceLeaderCorporateEvents",
                columns: new[] { "CorporateEventID", "WorkPlaceLeaderID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeCorporateEvents",
                table: "EmployeeCorporateEvents",
                columns: new[] { "CorporateEventID", "EmployeeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCorporateEvents_CorporateEvents_CorporateEventID",
                table: "EmployeeCorporateEvents",
                column: "CorporateEventID",
                principalTable: "CorporateEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCorporateEvents_Employees_EmployeeID",
                table: "EmployeeCorporateEvents",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceLeaderCorporateEvents_CorporateEvents_CorporateEventID",
                table: "WorkPlaceLeaderCorporateEvents",
                column: "CorporateEventID",
                principalTable: "CorporateEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceLeaderCorporateEvents_WorkPlaceLeaders_WorkPlaceLeaderID",
                table: "WorkPlaceLeaderCorporateEvents",
                column: "WorkPlaceLeaderID",
                principalTable: "WorkPlaceLeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCorporateEvents_CorporateEvents_CorporateEventID",
                table: "EmployeeCorporateEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCorporateEvents_Employees_EmployeeID",
                table: "EmployeeCorporateEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceLeaderCorporateEvents_CorporateEvents_CorporateEventID",
                table: "WorkPlaceLeaderCorporateEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkPlaceLeaderCorporateEvents_WorkPlaceLeaders_WorkPlaceLeaderID",
                table: "WorkPlaceLeaderCorporateEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkPlaceLeaderCorporateEvents",
                table: "WorkPlaceLeaderCorporateEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeCorporateEvents",
                table: "EmployeeCorporateEvents");

            migrationBuilder.RenameTable(
                name: "WorkPlaceLeaderCorporateEvents",
                newName: "WorkPlaceLeaderCorporateEvent");

            migrationBuilder.RenameTable(
                name: "EmployeeCorporateEvents",
                newName: "EmployeeCorporateEvent");

            migrationBuilder.RenameIndex(
                name: "IX_WorkPlaceLeaderCorporateEvents_WorkPlaceLeaderID",
                table: "WorkPlaceLeaderCorporateEvent",
                newName: "IX_WorkPlaceLeaderCorporateEvent_WorkPlaceLeaderID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCorporateEvents_EmployeeID",
                table: "EmployeeCorporateEvent",
                newName: "IX_EmployeeCorporateEvent_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkPlaceLeaderCorporateEvent",
                table: "WorkPlaceLeaderCorporateEvent",
                columns: new[] { "CorporateEventID", "WorkPlaceLeaderID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeCorporateEvent",
                table: "EmployeeCorporateEvent",
                columns: new[] { "CorporateEventID", "EmployeeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCorporateEvent_CorporateEvents_CorporateEventID",
                table: "EmployeeCorporateEvent",
                column: "CorporateEventID",
                principalTable: "CorporateEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCorporateEvent_Employees_EmployeeID",
                table: "EmployeeCorporateEvent",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceLeaderCorporateEvent_CorporateEvents_CorporateEventID",
                table: "WorkPlaceLeaderCorporateEvent",
                column: "CorporateEventID",
                principalTable: "CorporateEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPlaceLeaderCorporateEvent_WorkPlaceLeaders_WorkPlaceLeaderID",
                table: "WorkPlaceLeaderCorporateEvent",
                column: "WorkPlaceLeaderID",
                principalTable: "WorkPlaceLeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
