using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium1.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    IdAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeedSpecialEquipment = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Action_pk", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "Firefighter",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("firefighter_pk", x => x.IdFirefighter);
                });

            migrationBuilder.CreateTable(
                name: "Firetruck",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationalNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("firetruck_pk", x => x.IdFireTruck);
                });

            migrationBuilder.CreateTable(
                name: "Firefighter_action",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Firefighteraction_pk", x => new { x.IdAction, x.IdFirefighter });
                    table.ForeignKey(
                        name: "FK_Firefighter_action_Action_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Action",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firefighter_action_Firefighter_IdFirefighter",
                        column: x => x.IdFirefighter,
                        principalTable: "Firefighter",
                        principalColumn: "IdFirefighter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Firetruck_action",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false),
                    IdFireTruckAction = table.Column<int>(type: "int", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Firetruck_action_pk", x => new { x.IdAction, x.IdFireTruck });
                    table.ForeignKey(
                        name: "FK_Firetruck_action_Action_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Action",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firetruck_action_Firetruck_IdFireTruck",
                        column: x => x.IdFireTruck,
                        principalTable: "Firetruck",
                        principalColumn: "IdFireTruck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firefighter_action_IdFirefighter",
                table: "Firefighter_action",
                column: "IdFirefighter");

            migrationBuilder.CreateIndex(
                name: "IX_Firetruck_action_IdFireTruck",
                table: "Firetruck_action",
                column: "IdFireTruck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firefighter_action");

            migrationBuilder.DropTable(
                name: "Firetruck_action");

            migrationBuilder.DropTable(
                name: "Firefighter");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Firetruck");
        }
    }
}
