using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dados.Migrations
{
    /// <inheritdoc />
    public partial class ListasAjuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkNota_Notas_NotasId",
                table: "LinkNota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.RenameTable(
                name: "Notas",
                newName: "Nota");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nota",
                table: "Nota",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkNota_Nota_NotasId",
                table: "LinkNota",
                column: "NotasId",
                principalTable: "Nota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkNota_Nota_NotasId",
                table: "LinkNota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nota",
                table: "Nota");

            migrationBuilder.RenameTable(
                name: "Nota",
                newName: "Notas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkNota_Notas_NotasId",
                table: "LinkNota",
                column: "NotasId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
