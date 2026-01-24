using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class addcolumtofilteredproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FabricTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FabricType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductProjectCategory",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ProjectCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProjectCategory", x => new { x.ProductsId, x.ProjectCategoryId });
                    table.ForeignKey(
                        name: "FK_ProductProjectCategory_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProjectCategory_ProjectCategory_ProjectCategoryId",
                        column: x => x.ProjectCategoryId,
                        principalTable: "ProjectCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FabricTypeId",
                table: "Products",
                column: "FabricTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProjectCategory_ProjectCategoryId",
                table: "ProductProjectCategory",
                column: "ProjectCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FabricType_FabricTypeId",
                table: "Products",
                column: "FabricTypeId",
                principalTable: "FabricType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FabricType_FabricTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FabricType");

            migrationBuilder.DropTable(
                name: "ProductProjectCategory");

            migrationBuilder.DropTable(
                name: "ProjectCategory");

            migrationBuilder.DropIndex(
                name: "IX_Products_FabricTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FabricTypeId",
                table: "Products");
        }
    }
}
