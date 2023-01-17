using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientInformationSystem.Migrations
{
    public partial class PatientsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistorys_Patients_IdMed",
                table: "MedicalHistorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistorys_IdMed",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IdMed",
                table: "MedicalHistorys");

            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "Patients",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "MedicalHistorys",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistorys_IdPatient",
                table: "MedicalHistorys",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistorys_Patients_IdPatient",
                table: "MedicalHistorys",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistorys_Patients_IdPatient",
                table: "MedicalHistorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistorys_IdPatient",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "MedicalHistorys");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdMed",
                table: "MedicalHistorys",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistorys_IdMed",
                table: "MedicalHistorys",
                column: "IdMed");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistorys_Patients_IdMed",
                table: "MedicalHistorys",
                column: "IdMed",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
