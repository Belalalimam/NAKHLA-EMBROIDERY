using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProjectCategory_ProjectCategory_ProjectCategoryId",
                table: "ProductProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FabricType_FabricTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectCategory",
                table: "ProjectCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FabricType",
                table: "FabricType");

            migrationBuilder.RenameTable(
                name: "ProjectCategory",
                newName: "projectCategories");

            migrationBuilder.RenameTable(
                name: "FabricType",
                newName: "fabricTypes");

            migrationBuilder.RenameColumn(
                name: "ProjectCategoryId",
                table: "ProductProjectCategory",
                newName: "ProjectCategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProjectCategory_ProjectCategoryId",
                table: "ProductProjectCategory",
                newName: "IX_ProductProjectCategory_ProjectCategoriesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectCategories",
                table: "projectCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fabricTypes",
                table: "fabricTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "productColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productColors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productColors_ProductId",
                table: "productColors",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProjectCategory_projectCategories_ProjectCategoriesId",
                table: "ProductProjectCategory",
                column: "ProjectCategoriesId",
                principalTable: "projectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_fabricTypes_FabricTypeId",
                table: "Products",
                column: "FabricTypeId",
                principalTable: "fabricTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProjectCategory_projectCategories_ProjectCategoriesId",
                table: "ProductProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_fabricTypes_FabricTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "productColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectCategories",
                table: "projectCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fabricTypes",
                table: "fabricTypes");

            migrationBuilder.RenameTable(
                name: "projectCategories",
                newName: "ProjectCategory");

            migrationBuilder.RenameTable(
                name: "fabricTypes",
                newName: "FabricType");

            migrationBuilder.RenameColumn(
                name: "ProjectCategoriesId",
                table: "ProductProjectCategory",
                newName: "ProjectCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProjectCategory_ProjectCategoriesId",
                table: "ProductProjectCategory",
                newName: "IX_ProductProjectCategory_ProjectCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectCategory",
                table: "ProjectCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FabricType",
                table: "FabricType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProjectCategory_ProjectCategory_ProjectCategoryId",
                table: "ProductProjectCategory",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FabricType_FabricTypeId",
                table: "Products",
                column: "FabricTypeId",
                principalTable: "FabricType",
                principalColumn: "Id");
        }
    }
}
