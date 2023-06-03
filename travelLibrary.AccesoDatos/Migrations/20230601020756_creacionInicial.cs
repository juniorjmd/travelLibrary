using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelLibrary.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class creacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sede = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Editoriales_id = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false),
                    Sinopsis = table.Column<string>(type: "TEXT", nullable: false),
                    n_paginas = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_Editoriales_id",
                        column: x => x.Editoriales_id,
                        principalTable: "Editoriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autores_has_libros",
                columns: table => new
                {
                    Autores_id = table.Column<int>(type: "int", nullable: false),
                    Libros_ISBN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Autores_has_libros_Autores_Autores_id",
                        column: x => x.Autores_id,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autores_has_libros_Libros_Libros_ISBN",
                        column: x => x.Libros_ISBN,
                        principalTable: "Libros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_has_libros_Autores_id",
                table: "Autores_has_libros",
                column: "Autores_id");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_has_libros_Libros_ISBN",
                table: "Autores_has_libros",
                column: "Libros_ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Editoriales_id",
                table: "Libros",
                column: "Editoriales_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores_has_libros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Editoriales");
        }
    }
}
