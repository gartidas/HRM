using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Vzdelanie = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    RequestedSalary = table.Column<double>(nullable: false),
                    Evaluation = table.Column<int>(nullable: false),
                    MyProperty = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CorporateEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RequestDescription = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    DateAndTime = table.Column<DateTime>(nullable: false),
                    GrantedByID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateEvents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormerEmployees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    BirthCertificateNumber = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressOfPermanentResidence = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    NumberOfVacationDays = table.Column<int>(nullable: false),
                    NumberOfWorkedOffDays = table.Column<int>(nullable: false),
                    TerminationReason = table.Column<string>(nullable: true),
                    TerminationDate = table.Column<DateTime>(nullable: false),
                    TerminatedByID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormerEmployees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workplaces",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    LeadByID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplaces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    BirthCertificateNumber = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressOfPermanentResidence = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    NumberOfVacationDays = table.Column<int>(nullable: false),
                    NumberOfWorkedOffDays = table.Column<int>(nullable: false),
                    WorkPlaceID = table.Column<int>(nullable: false),
                    EquipmentStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Workplaces_WorkPlaceID",
                        column: x => x.WorkPlaceID,
                        principalTable: "Workplaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    WorkplaceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Specialties_Workplaces_WorkplaceID",
                        column: x => x.WorkplaceID,
                        principalTable: "Workplaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bonuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    GrantedDate = table.Column<DateTime>(nullable: false),
                    GrantedByID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bonuses_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false),
                    FormerEmployeeID = table.Column<int>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Documents_Candidates_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Candidates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_FormerEmployees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "FormerEmployees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCorporateEvent",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false),
                    CorporateEventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCorporateEvent", x => new { x.CorporateEventID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_EmployeeCorporateEvent_CorporateEvents_CorporateEventID",
                        column: x => x.CorporateEventID,
                        principalTable: "CorporateEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCorporateEvent_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipment_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    GrantedByID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Evaluations_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTime = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    ApprovedBy = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_EmployeeID",
                table: "Bonuses",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EmployeeID",
                table: "Documents",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCorporateEvent_EmployeeID",
                table: "EmployeeCorporateEvent",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkPlaceID",
                table: "Employees",
                column: "WorkPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EmployeeID",
                table: "Equipment",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_EmployeeID",
                table: "Evaluations",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_WorkplaceID",
                table: "Specialties",
                column: "WorkplaceID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_EmployeeID",
                table: "UserAccounts",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeID",
                table: "Vacations",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonuses");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EmployeeCorporateEvent");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "FormerEmployees");

            migrationBuilder.DropTable(
                name: "CorporateEvents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Workplaces");
        }
    }
}
