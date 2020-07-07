using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SegundoParcial.AP1.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    TareaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    TipoTarea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.TareaId);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTarea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleTarea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<int>(nullable: false),
                    TareaId = table.Column<int>(nullable: false),
                    Requerimiento = table.Column<string>(nullable: true),
                    Tiempo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleTarea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleTarea_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Proyecto",
                columns: new[] { "TareaId", "TipoTarea", "fecha" },
                values: new object[] { 1, "Analicis", new DateTime(2020, 7, 6, 22, 16, 23, 372, DateTimeKind.Local).AddTicks(7037) });

            migrationBuilder.InsertData(
                table: "Proyecto",
                columns: new[] { "TareaId", "TipoTarea", "fecha" },
                values: new object[] { 2, "Programacion", new DateTime(2020, 7, 6, 22, 16, 23, 377, DateTimeKind.Local).AddTicks(1531) });

            migrationBuilder.InsertData(
                table: "Proyecto",
                columns: new[] { "TareaId", "TipoTarea", "fecha" },
                values: new object[] { 3, "Prueba", new DateTime(2020, 7, 6, 22, 16, 23, 377, DateTimeKind.Local).AddTicks(1878) });

            migrationBuilder.InsertData(
                table: "Proyecto",
                columns: new[] { "TareaId", "TipoTarea", "fecha" },
                values: new object[] { 4, "Diseño", new DateTime(2020, 7, 6, 22, 16, 23, 377, DateTimeKind.Local).AddTicks(1930) });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTarea_ProyectoId",
                table: "DetalleTarea",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleTarea");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Proyecto");
        }
    }
}
