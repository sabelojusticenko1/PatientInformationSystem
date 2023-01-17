using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientInformationSystem.Migrations
{
    public partial class MappModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdNote",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMed",
                table: "MedicalHistorys",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_IdNote",
                table: "Notes",
                column: "IdNote");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_MedicalHistorys_IdNote",
                table: "Notes",
                column: "IdNote",
                principalTable: "MedicalHistorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistorys_Patients_IdMed",
                table: "MedicalHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_MedicalHistorys_IdNote",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_IdNote",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistorys_IdMed",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "IdNote",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IdMed",
                table: "MedicalHistorys");
        }
    }
}
