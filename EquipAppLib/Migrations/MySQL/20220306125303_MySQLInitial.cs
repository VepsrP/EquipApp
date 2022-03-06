using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipAppLib.Migrations.MySQL
{
    public partial class MySQLInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypesEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesEquipment", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workplaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CabinetId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workplaces_Cabinets_CabinetId",
                        column: x => x.CabinetId,
                        principalTable: "Cabinets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workplaces_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ParameterTypeEquipment",
                columns: table => new
                {
                    EquipmentTypesId = table.Column<int>(type: "int", nullable: false),
                    ParametersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterTypeEquipment", x => new { x.EquipmentTypesId, x.ParametersId });
                    table.ForeignKey(
                        name: "FK_ParameterTypeEquipment_Parameters_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterTypeEquipment_TypesEquipment_EquipmentTypesId",
                        column: x => x.EquipmentTypesId,
                        principalTable: "TypesEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InventoryNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkplaceId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_TypesEquipment_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypesEquipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipments_Workplaces_WorkplaceId",
                        column: x => x.WorkplaceId,
                        principalTable: "Workplaces",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EquipmentsParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    ParameterId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentsParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentsParameters_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentsParameters_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_TypeId",
                table: "Equipments",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_WorkplaceId",
                table: "Equipments",
                column: "WorkplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsParameters_EquipmentId",
                table: "EquipmentsParameters",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsParameters_ParameterId",
                table: "EquipmentsParameters",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterTypeEquipment_ParametersId",
                table: "ParameterTypeEquipment",
                column: "ParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Workplaces_CabinetId",
                table: "Workplaces",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Workplaces_EmployeeId",
                table: "Workplaces",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentsParameters");

            migrationBuilder.DropTable(
                name: "ParameterTypeEquipment");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "TypesEquipment");

            migrationBuilder.DropTable(
                name: "Workplaces");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
