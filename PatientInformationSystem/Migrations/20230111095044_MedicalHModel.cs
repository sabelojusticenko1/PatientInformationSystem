using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientInformationSystem.Migrations
{
    public partial class MedicalHModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_MedicalHistorys_IdNote",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_IdNote",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistorys",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "IdNote",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MedicalHistorys");

            migrationBuilder.AddColumn<int>(
                name: "IdMedicalHistory",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMedicalHistory",
                table: "MedicalHistorys",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistorys",
                table: "MedicalHistorys",
                column: "IdMedicalHistory");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_IdMedicalHistory",
                table: "Notes",
                column: "IdMedicalHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_MedicalHistorys_IdMedicalHistory",
                table: "Notes",
                column: "IdMedicalHistory",
                principalTable: "MedicalHistorys",
                principalColumn: "IdMedicalHistory",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_MedicalHistorys_IdMedicalHistory",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_IdMedicalHistory",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistorys",
                table: "MedicalHistorys");

            migrationBuilder.DropColumn(
                name: "IdMedicalHistory",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IdMedicalHistory",
                table: "MedicalHistorys");

            migrationBuilder.AddColumn<int>(
                name: "IdNote",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MedicalHistorys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistorys",
                table: "MedicalHistorys",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_IdNote",
                table: "Notes",
                column: "IdNote");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_MedicalHistorys_IdNote",
                table: "Notes",
                column: "IdNote",
                principalTable: "MedicalHistorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
