using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenia8.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IMedicamentNavigationIdMedicament",
                table: "Prescription_medicament",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionsIdPrescription",
                table: "Prescription_medicament",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_medicament_IMedicamentNavigationIdMedicament",
                table: "Prescription_medicament",
                column: "IMedicamentNavigationIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_medicament_PrescriptionsIdPrescription",
                table: "Prescription_medicament",
                column: "PrescriptionsIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_medicament_Medicament_IMedicamentNavigationIdMedicament",
                table: "Prescription_medicament",
                column: "IMedicamentNavigationIdMedicament",
                principalTable: "Medicament",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_medicament_Prescription_PrescriptionsIdPrescription",
                table: "Prescription_medicament",
                column: "PrescriptionsIdPrescription",
                principalTable: "Prescription",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_medicament_Medicament_IMedicamentNavigationIdMedicament",
                table: "Prescription_medicament");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_medicament_Prescription_PrescriptionsIdPrescription",
                table: "Prescription_medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_medicament_IMedicamentNavigationIdMedicament",
                table: "Prescription_medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_medicament_PrescriptionsIdPrescription",
                table: "Prescription_medicament");

            migrationBuilder.DropColumn(
                name: "IMedicamentNavigationIdMedicament",
                table: "Prescription_medicament");

            migrationBuilder.DropColumn(
                name: "PrescriptionsIdPrescription",
                table: "Prescription_medicament");
        }
    }
}
