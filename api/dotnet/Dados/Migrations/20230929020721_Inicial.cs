using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dados.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(MAX)", maxLength: 40, nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caminho = table.Column<string>(type: "varchar(260)", maxLength: 260, nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(MAX)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkNota",
                columns: table => new
                {
                    NotasId = table.Column<int>(type: "int", nullable: false),
                    UrlsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkNota", x => new { x.NotasId, x.UrlsId });
                    table.ForeignKey(
                        name: "FK_LinkNota_Link_UrlsId",
                        column: x => x.UrlsId,
                        principalTable: "Link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkNota_Nota_NotasId",
                        column: x => x.NotasId,
                        principalTable: "Nota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_Url",
                table: "Link",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LinkNota_UrlsId",
                table: "LinkNota",
                column: "UrlsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_Nome",
                table: "Lista",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkNota");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "Nota");
        }
    }
}
