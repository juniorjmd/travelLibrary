using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelLibrary.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ultimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdRegistro",
                table: "Autores_has_libros",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Autores_has_libros",
                newName: "IdRegistro");
        }
    }
}
