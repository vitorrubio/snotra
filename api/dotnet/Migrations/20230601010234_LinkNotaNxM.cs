using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnotraApiDotNet.Migrations
{
    /// <inheritdoc />
    public partial class LinkNotaNxM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_Notas_NotaId",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_NotaId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "NotaId",
                table: "Link");

            migrationBuilder.CreateTable(
                name: "LinkModeloNotaModelo",
                columns: table => new
                {
                    NotasId = table.Column<int>(type: "int", nullable: false),
                    UrlsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkModeloNotaModelo", x => new { x.NotasId, x.UrlsId });
                    table.ForeignKey(
                        name: "FK_LinkModeloNotaModelo_Link_UrlsId",
                        column: x => x.UrlsId,
                        principalTable: "Link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkModeloNotaModelo_Notas_NotasId",
                        column: x => x.NotasId,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkModeloNotaModelo_UrlsId",
                table: "LinkModeloNotaModelo",
                column: "UrlsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkModeloNotaModelo");

            migrationBuilder.AddColumn<int>(
                name: "NotaId",
                table: "Link",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_NotaId",
                table: "Link",
                column: "NotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Notas_NotaId",
                table: "Link",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id");
        }
    }
}
