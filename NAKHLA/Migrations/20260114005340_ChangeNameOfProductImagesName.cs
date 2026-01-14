using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOfProductImagesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSubImages_Products_ProductId",
                table: "ProductSubImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSubImages",
                table: "ProductSubImages");

            migrationBuilder.RenameTable(
                name: "ProductSubImages",
                newName: "productImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSubImages_ProductId",
                table: "productImages",
                newName: "IX_productImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productImages",
                table: "productImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productImages_Products_ProductId",
                table: "productImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productImages_Products_ProductId",
                table: "productImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productImages",
                table: "productImages");

            migrationBuilder.RenameTable(
                name: "productImages",
                newName: "ProductSubImages");

            migrationBuilder.RenameIndex(
                name: "IX_productImages_ProductId",
                table: "ProductSubImages",
                newName: "IX_ProductSubImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSubImages",
                table: "ProductSubImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSubImages_Products_ProductId",
                table: "ProductSubImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
