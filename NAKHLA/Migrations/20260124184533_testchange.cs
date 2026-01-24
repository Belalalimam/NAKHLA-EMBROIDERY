using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class testchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productAttributes_Products_ProductId",
                table: "productAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_productColors_Products_ProductId",
                table: "productColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductTag_productTags_ProductTagsId",
                table: "ProductProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProjectCategory_projectCategories_ProjectCategoriesId",
                table: "ProductProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_productReviews_Products_ProductId",
                table: "productReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_fabricTypes_FabricTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectCategories",
                table: "projectCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productTags",
                table: "productTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productReviews",
                table: "productReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productColors",
                table: "productColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productAttributes",
                table: "productAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fabricTypes",
                table: "fabricTypes");

            migrationBuilder.RenameTable(
                name: "projectCategories",
                newName: "ProjectCategories");

            migrationBuilder.RenameTable(
                name: "productTags",
                newName: "ProductTags");

            migrationBuilder.RenameTable(
                name: "productReviews",
                newName: "ProductReviews");

            migrationBuilder.RenameTable(
                name: "productColors",
                newName: "ProductColors");

            migrationBuilder.RenameTable(
                name: "productAttributes",
                newName: "ProductAttributes");

            migrationBuilder.RenameTable(
                name: "fabricTypes",
                newName: "FabricTypes");

            migrationBuilder.RenameIndex(
                name: "IX_productReviews_ProductId",
                table: "ProductReviews",
                newName: "IX_ProductReviews_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productColors_ProductId",
                table: "ProductColors",
                newName: "IX_ProductColors_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productAttributes_ProductId",
                table: "ProductAttributes",
                newName: "IX_ProductAttributes_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectCategories",
                table: "ProjectCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductReviews",
                table: "ProductReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColors",
                table: "ProductColors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FabricTypes",
                table: "FabricTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColors_Products_ProductId",
                table: "ProductColors",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductTag_ProductTags_ProductTagsId",
                table: "ProductProductTag",
                column: "ProductTagsId",
                principalTable: "ProductTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProjectCategory_ProjectCategories_ProjectCategoriesId",
                table: "ProductProjectCategory",
                column: "ProjectCategoriesId",
                principalTable: "ProjectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Products_ProductId",
                table: "ProductReviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FabricTypes_FabricTypeId",
                table: "Products",
                column: "FabricTypeId",
                principalTable: "FabricTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColors_Products_ProductId",
                table: "ProductColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductTag_ProductTags_ProductTagsId",
                table: "ProductProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProjectCategory_ProjectCategories_ProjectCategoriesId",
                table: "ProductProjectCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Products_ProductId",
                table: "ProductReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FabricTypes_FabricTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectCategories",
                table: "ProjectCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductReviews",
                table: "ProductReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColors",
                table: "ProductColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FabricTypes",
                table: "FabricTypes");

            migrationBuilder.RenameTable(
                name: "ProjectCategories",
                newName: "projectCategories");

            migrationBuilder.RenameTable(
                name: "ProductTags",
                newName: "productTags");

            migrationBuilder.RenameTable(
                name: "ProductReviews",
                newName: "productReviews");

            migrationBuilder.RenameTable(
                name: "ProductColors",
                newName: "productColors");

            migrationBuilder.RenameTable(
                name: "ProductAttributes",
                newName: "productAttributes");

            migrationBuilder.RenameTable(
                name: "FabricTypes",
                newName: "fabricTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductReviews_ProductId",
                table: "productReviews",
                newName: "IX_productReviews_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColors_ProductId",
                table: "productColors",
                newName: "IX_productColors_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "productAttributes",
                newName: "IX_productAttributes_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectCategories",
                table: "projectCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productTags",
                table: "productTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productReviews",
                table: "productReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productColors",
                table: "productColors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productAttributes",
                table: "productAttributes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fabricTypes",
                table: "fabricTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productAttributes_Products_ProductId",
                table: "productAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productColors_Products_ProductId",
                table: "productColors",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductTag_productTags_ProductTagsId",
                table: "ProductProductTag",
                column: "ProductTagsId",
                principalTable: "productTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProjectCategory_projectCategories_ProjectCategoriesId",
                table: "ProductProjectCategory",
                column: "ProjectCategoriesId",
                principalTable: "projectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productReviews_Products_ProductId",
                table: "productReviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_fabricTypes_FabricTypeId",
                table: "Products",
                column: "FabricTypeId",
                principalTable: "fabricTypes",
                principalColumn: "Id");
        }
    }
}
