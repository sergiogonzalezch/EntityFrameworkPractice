using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fundamentos_Entity_Framework_C_.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Time" },
                values: new object[,]
                {
                    { new Guid("d638cf70-1148-430a-9c06-04439e6c90c6"), "Actividades sin realizar", "Actividades pendientes", 0 },
                    { new Guid("d638cf70-1148-430a-9c06-04439e6c90c7"), "Actividades de mi interes personal", "Actividades Personales", 5 }
                });

            migrationBuilder.InsertData(
                table: "Homework",
                columns: new[] { "HomeworkId", "CategoryId", "CreatedAt", "Description", "Priority", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2fd130f6-f752-4e5e-ae63-1c1410a2c920"), new Guid("d638cf70-1148-430a-9c06-04439e6c90c7"), new DateTime(2025, 3, 7, 0, 46, 27, 834, DateTimeKind.Utc).AddTicks(6852), "Elaborar y revisar el informe de rendimiento del mes", 0, "Preparar informe mensual", new DateTime(2025, 3, 7, 0, 46, 27, 834, DateTimeKind.Utc).AddTicks(6855) },
                    { new Guid("2fd130f6-f752-4e5e-ae63-1c1410a2c921"), new Guid("d638cf70-1148-430a-9c06-04439e6c90c6"), new DateTime(2025, 3, 7, 0, 46, 27, 834, DateTimeKind.Utc).AddTicks(6858), "Seleccionar y leer al menos un capítulo del libro", 1, "Leer un libro de desarrollo personal", new DateTime(2025, 3, 7, 0, 46, 27, 834, DateTimeKind.Utc).AddTicks(6858) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("2fd130f6-f752-4e5e-ae63-1c1410a2c920"));

            migrationBuilder.DeleteData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("2fd130f6-f752-4e5e-ae63-1c1410a2c921"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("d638cf70-1148-430a-9c06-04439e6c90c6"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("d638cf70-1148-430a-9c06-04439e6c90c7"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
