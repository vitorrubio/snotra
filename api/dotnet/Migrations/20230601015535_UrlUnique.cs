using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnotraApiDotNet.Migrations
{
    /// <inheritdoc />
    public partial class UrlUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Link_Url",
                table: "Link",
                column: "Url",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Link_Url",
                table: "Link");
        }
    }
}
