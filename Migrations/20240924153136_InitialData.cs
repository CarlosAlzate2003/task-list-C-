using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Importancia", "Nombre" },
                values: new object[,]
                {
                    { new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf02"), null, 50, "Actividades Personales" },
                    { new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf6c"), null, 20, "Actividades Pendientes" }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf01"), new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf6c"), "Estudiar C# desde cero", new DateTime(2024, 9, 24, 10, 31, 35, 827, DateTimeKind.Local).AddTicks(1006), 1, "Estudiar C#" },
                    { new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf05"), new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf02"), "Ver Netflix", new DateTime(2024, 9, 24, 10, 31, 35, 828, DateTimeKind.Local).AddTicks(6326), 0, "Terminar de ver peliculas en Netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf01"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf05"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("5d8c1bcb-4242-41ae-ac34-f44922c5bf6c"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
