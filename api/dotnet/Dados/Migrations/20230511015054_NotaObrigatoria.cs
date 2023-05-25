using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnotraApiDotNet.Dados.Migrations
{
    /// <inheritdoc />
    public partial class NotaObrigatoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_Notas_NotaId",
                table: "Link");

            migrationBuilder.AlterColumn<int>(
                name: "NotaId",
                table: "Link",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Notas_NotaId",
                table: "Link",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_Notas_NotaId",
                table: "Link");

            migrationBuilder.AlterColumn<int>(
                name: "NotaId",
                table: "Link",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Notas_NotaId",
                table: "Link",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id");
        }
    }
}
