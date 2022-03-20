using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AdPatientUsernameAndEmailToAppointmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientUsername",
                table: "Appointments",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientUsername",
                table: "Appointments");
        }
    }
}
