using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swaapapi.Migrations
{
    /// <inheritdoc />
    public partial class addCatalogItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CatalogItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CategoryId",
                table: "CatalogItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItems_Categories_CategoryId",
                table: "CatalogItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItems_Categories_CategoryId",
                table: "CatalogItems");

            migrationBuilder.DropIndex(
                name: "IX_CatalogItems_CategoryId",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CatalogItems");
        }
    }
}
