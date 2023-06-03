using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelLibrary.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibrosISBN",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_LibrosISBN",
                table: "Autores",
                column: "LibrosISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Libros_LibrosISBN",
                table: "Autores",
                column: "LibrosISBN",
                principalTable: "Libros",
                principalColumn: "ISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Libros_LibrosISBN",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_LibrosISBN",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "LibrosISBN",
                table: "Autores");
        }
    }
}
