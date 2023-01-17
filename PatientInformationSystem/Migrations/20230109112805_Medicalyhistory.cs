using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientInformationSystem.Migrations
{
    public partial class Medicalyhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistorys_Patients_IdPatient",
                table: "MedicalHistorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stages",
                table: "Stages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistorys",
                table: "MedicalHistorys");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistorys_IdPatient",
                table: "MedicalHistorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosiss",
                table: "Diagnosiss");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "IdIdMedicalHistory",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "DiagnosisId",
                table: "Diagnosiss");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Stages",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MedicalHistorys",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Diagnosiss",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stages",
                table: "Stages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistorys",
                table: "MedicalHistorys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosiss",
                table: "Diagnosiss",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stages",
                table: "Stages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistorys",
                table: "MedicalHistorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosiss",
                table: "Diagnosiss");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Diagnosiss");

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "Stages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdIdMedicalHistory",
                table: "MedicalHistorys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "MedicalHistorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "MedicalHistorys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiagnosisId",
                table: "Diagnosiss",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stages",
                table: "Stages",
                column: "StageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistorys",
                table: "MedicalHistorys",
                column: "IdIdMedicalHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosiss",
                table: "Diagnosiss",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistorys_IdPatient",
                table: "MedicalHistorys",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistorys_Patients_IdPatient",
                table: "MedicalHistorys",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
