using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateRelationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<decimal>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<decimal>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Education = table.Column<string>(nullable: true),
                    WorkingHours = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    DepartamentId = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorTimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ToTime = table.Column<TimeSpan>(nullable: false),
                    FromTime = table.Column<TimeSpan>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorTimeSlots_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointDate = table.Column<DateTime>(nullable: false),
                    DoctorComment = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true),
                    DoctorTimeSlotId = table.Column<int>(nullable: true),
                    IsChecked = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_DoctorTimeSlots_DoctorTimeSlotId",
                        column: x => x.DoctorTimeSlotId,
                        principalTable: "DoctorTimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorTimeSlotId",
                table: "Appointments",
                column: "DoctorTimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartamentId",
                table: "Doctors",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTimeSlots_DoctorId",
                table: "DoctorTimeSlots",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorTimeSlots");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Departaments");
        }
    }
}
