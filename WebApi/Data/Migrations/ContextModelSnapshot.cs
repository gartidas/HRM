﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApi.Entities.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebApi.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AccountNumber");

                    b.Property<string>("AddressOfPermanentResidence");

                    b.Property<string>("BirthCertificateNumber");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthPlace");

                    b.Property<string>("Citizenship");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DrivingLicenceNumber");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("EquipmentStatus");

                    b.Property<int>("FamilyStatus");

                    b.Property<bool>("Gender");

                    b.Property<string>("HealthInsuranceCompany");

                    b.Property<string>("IdCardNumber");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NameOfTheBank");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int>("NumberOfChildren");

                    b.Property<int>("NumberOfVacationDays");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<double>("Salary");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Specialty");

                    b.Property<string>("Surname");

                    b.Property<string>("Title");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApi.Entities.Bonus", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("EmployeeID");

                    b.Property<DateTime>("GrantedDate");

                    b.Property<string>("HR_WorkerID");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("HR_WorkerID");

                    b.ToTable("Bonuses");
                });

            modelBuilder.Entity("WebApi.Entities.Candidate", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfo");

                    b.Property<string>("Address");

                    b.Property<string>("Education");

                    b.Property<string>("Email");

                    b.Property<int>("Evaluation");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<double>("RequestedSalary");

                    b.Property<string>("Specialty");

                    b.Property<int>("Status");

                    b.Property<string>("Surname");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("WebApi.Entities.CorporateEvent", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAndTime");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("RequestDescription");

                    b.HasKey("ID");

                    b.ToTable("CorporateEvents");
                });

            modelBuilder.Entity("WebApi.Entities.Document", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CandidateID");

                    b.Property<byte[]>("Content");

                    b.Property<string>("EmployeeID");

                    b.Property<string>("FormerEmployeeID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("FormerEmployeeID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("WebApi.Entities.Employee", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasChangedRole");

                    b.Property<string>("IdentityUserId")
                        .IsRequired();

                    b.Property<string>("WorkPlaceID");

                    b.HasKey("ID");

                    b.HasIndex("IdentityUserId");

                    b.HasIndex("WorkPlaceID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApi.Entities.Equipment", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeID");

                    b.Property<string>("Label");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("WebApi.Entities.Evaluation", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("EmployeeID");

                    b.Property<string>("HR_WorkerID");

                    b.Property<bool>("Type");

                    b.Property<int>("Weight");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("HR_WorkerID");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("WebApi.Entities.FormerEmployee", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressOfPermanentResidence");

                    b.Property<string>("BirthCertificateNumber");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthPlace");

                    b.Property<string>("Citizenship");

                    b.Property<string>("Email");

                    b.Property<bool>("Gender");

                    b.Property<string>("HR_WorkerID");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfVacationDays");

                    b.Property<string>("PhoneNumber");

                    b.Property<double>("Salary");

                    b.Property<string>("Specialty");

                    b.Property<string>("Surname");

                    b.Property<DateTime>("TerminationDate");

                    b.Property<string>("TerminationReason");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("HR_WorkerID");

                    b.ToTable("FormerEmployees");
                });

            modelBuilder.Entity("WebApi.Entities.HR_Worker", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasChangedRole");

                    b.Property<string>("IdentityUserId")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("HR_Workers");
                });

            modelBuilder.Entity("WebApi.Entities.Joins.EmployeeCorporateEvent", b =>
                {
                    b.Property<string>("CorporateEventID");

                    b.Property<string>("EmployeeID");

                    b.HasKey("CorporateEventID", "EmployeeID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("EmployeeCorporateEvents");
                });

            modelBuilder.Entity("WebApi.Entities.Joins.WorkPlaceLeaderCorporateEvent", b =>
                {
                    b.Property<string>("CorporateEventID");

                    b.Property<string>("WorkPlaceLeaderID");

                    b.HasKey("CorporateEventID", "WorkPlaceLeaderID");

                    b.HasIndex("WorkPlaceLeaderID");

                    b.ToTable("WorkPlaceLeaderCorporateEvents");
                });

            modelBuilder.Entity("WebApi.Entities.Specialty", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfEmployees");

                    b.Property<bool>("Type");

                    b.Property<string>("WorkplaceID");

                    b.HasKey("ID");

                    b.HasIndex("WorkplaceID");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("WebApi.Entities.Vacation", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<DateTime>("DateAndTime");

                    b.Property<string>("EmployeeID");

                    b.Property<string>("Reason");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("WebApi.Entities.WorkPlace", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.Property<string>("Location");

                    b.Property<string>("WorkPlaceLeaderID");

                    b.HasKey("ID");

                    b.HasIndex("WorkPlaceLeaderID")
                        .IsUnique()
                        .HasFilter("[WorkPlaceLeaderID] IS NOT NULL");

                    b.ToTable("Workplaces");
                });

            modelBuilder.Entity("WebApi.Entities.WorkPlaceLeader", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasChangedRole");

                    b.Property<string>("IdentityUserId")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("WorkPlaceLeaders");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("WebApi.Entities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApi.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApi.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("WebApi.Entities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApi.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Bonus", b =>
                {
                    b.HasOne("WebApi.Entities.Employee", "Employee")
                        .WithMany("Bonuses")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.HR_Worker", "HR_Worker")
                        .WithMany("Bonuses")
                        .HasForeignKey("HR_WorkerID");
                });

            modelBuilder.Entity("WebApi.Entities.Document", b =>
                {
                    b.HasOne("WebApi.Entities.Candidate", "Candidate")
                        .WithMany("Documentation")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Employee", "Employee")
                        .WithMany("Documentation")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.FormerEmployee", "FormerEmployee")
                        .WithMany("Documentation")
                        .HasForeignKey("FormerEmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Employee", b =>
                {
                    b.HasOne("WebApi.Entities.ApplicationUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.WorkPlace", "WorkPlace")
                        .WithMany("Employees")
                        .HasForeignKey("WorkPlaceID");
                });

            modelBuilder.Entity("WebApi.Entities.Equipment", b =>
                {
                    b.HasOne("WebApi.Entities.Employee", "Employee")
                        .WithMany("Equipment")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Evaluation", b =>
                {
                    b.HasOne("WebApi.Entities.Employee", "Employee")
                        .WithMany("Evaluations")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.HR_Worker", "HR_Worker")
                        .WithMany("Evaluations")
                        .HasForeignKey("HR_WorkerID");
                });

            modelBuilder.Entity("WebApi.Entities.FormerEmployee", b =>
                {
                    b.HasOne("WebApi.Entities.HR_Worker", "HR_Worker")
                        .WithMany("FormerEmployees")
                        .HasForeignKey("HR_WorkerID");
                });

            modelBuilder.Entity("WebApi.Entities.HR_Worker", b =>
                {
                    b.HasOne("WebApi.Entities.ApplicationUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Joins.EmployeeCorporateEvent", b =>
                {
                    b.HasOne("WebApi.Entities.CorporateEvent", "CorporateEvent")
                        .WithMany("EmployeeCorporateEvent")
                        .HasForeignKey("CorporateEventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Employee", "Employee")
                        .WithMany("EmployeeCorporateEvent")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Joins.WorkPlaceLeaderCorporateEvent", b =>
                {
                    b.HasOne("WebApi.Entities.CorporateEvent", "CorporateEvent")
                        .WithMany("WorkPlaceLeaderCorporateEvent")
                        .HasForeignKey("CorporateEventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.WorkPlaceLeader", "WorkPlaceLeader")
                        .WithMany("WorkPlaceLeaderCorporateEvent")
                        .HasForeignKey("WorkPlaceLeaderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Specialty", b =>
                {
                    b.HasOne("WebApi.Entities.WorkPlace", "Workplace")
                        .WithMany("Specialties")
                        .HasForeignKey("WorkplaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Vacation", b =>
                {
                    b.HasOne("WebApi.Entities.Employee", "Employee")
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.WorkPlace", b =>
                {
                    b.HasOne("WebApi.Entities.WorkPlaceLeader", "WorkPlaceLeader")
                        .WithOne("WorkPlace")
                        .HasForeignKey("WebApi.Entities.WorkPlace", "WorkPlaceLeaderID");
                });

            modelBuilder.Entity("WebApi.Entities.WorkPlaceLeader", b =>
                {
                    b.HasOne("WebApi.Entities.ApplicationUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
