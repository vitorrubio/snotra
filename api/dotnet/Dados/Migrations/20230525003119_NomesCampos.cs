using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnotraApiDotNet.Dados.Migrations
{
    /// <inheritdoc />
    public partial class NomesCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "C_CAMINHO",
                table: "Notas",
                newName: "Caminho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Caminho",
                table: "Notas",
                newName: "C_CAMINHO");
        }
    }
}
