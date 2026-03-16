using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class addNewTableCompositions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCompositions_Composition_CompositionId",
                table: "ProductCompositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Composition",
                table: "Composition");

            migrationBuilder.RenameTable(
                name: "Composition",
                newName: "Compositions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compositions",
                table: "Compositions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCompositions_Compositions_CompositionId",
                table: "ProductCompositions",
                column: "CompositionId",
                principalTable: "Compositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCompositions_Compositions_CompositionId",
                table: "ProductCompositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compositions",
                table: "Compositions");

            migrationBuilder.RenameTable(
                name: "Compositions",
                newName: "Composition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Composition",
                table: "Composition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCompositions_Composition_CompositionId",
                table: "ProductCompositions",
                column: "CompositionId",
                principalTable: "Composition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
