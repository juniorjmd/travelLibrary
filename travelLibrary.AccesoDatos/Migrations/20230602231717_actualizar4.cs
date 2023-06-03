using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelLibrary.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class actualizar4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.CreateTable(
                name: "Autores_has_libros",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autores_id = table.Column<int>(type: "int", nullable: false),
                    Libros_ISBN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {   table.PrimaryKey("PK_Autores_has_libros", x => x.IdRegistro); 
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Autores_has_libros",
                table: "Autores_has_libros");

            migrationBuilder.RenameColumn(
                name: "IdRegistro",
                table: "Autores_has_libros",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Autores_has_libros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
