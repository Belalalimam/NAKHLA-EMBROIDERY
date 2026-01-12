using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAndOrderItemTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_AspNetUsers_ApplicationUserId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_ApplicationUserId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PublishAt",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "ValidTo",
                table: "Promotions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Promotions",
                newName: "DiscountValue");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Promotions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Promotions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "ApplyToAllProducts",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ApplyToShipping",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ApplyToTax",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BadgeColor",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BannerImage",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BannerText",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Promotions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanCombineWithOtherPromotions",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CustomerMinOrderCount",
                table: "Promotions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CustomerMinPurchaseAmount",
                table: "Promotions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "Promotions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Promotions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExcludedPromotions",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForExistingCustomersOnly",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ForNewCustomersOnly",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MaximumDiscountAmount",
                table: "Promotions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumPurchaseAmount",
                table: "Promotions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Promotions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomepage",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Promotions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsageLimit",
                table: "Promotions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsageLimitPerCustomer",
                table: "Promotions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsedCount",
                table: "Promotions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShippingFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShippingCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShippingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShippingEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BillingCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BillingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcessingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShippingMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PromotionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AdminNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSku = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BrandId",
                table: "Promotions",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CategoryId",
                table: "Promotions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Brands_BrandId",
                table: "Promotions",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Categorise_CategoryId",
                table: "Promotions",
                column: "CategoryId",
                principalTable: "Categorise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Brands_BrandId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Categorise_CategoryId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_BrandId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_CategoryId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ApplyToAllProducts",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ApplyToShipping",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ApplyToTax",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "BadgeColor",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "BannerImage",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "BannerText",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CanCombineWithOtherPromotions",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CustomerMinOrderCount",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CustomerMinPurchaseAmount",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ExcludedPromotions",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ForExistingCustomersOnly",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ForNewCustomersOnly",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "MaximumDiscountAmount",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "MinimumPurchaseAmount",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ShowOnHomepage",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "UsageLimit",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "UsageLimitPerCustomer",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "UsedCount",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "DiscountValue",
                table: "Promotions",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Promotions",
                newName: "ValidTo");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Promotions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Promotions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishAt",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ApplicationUserId",
                table: "Promotions",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_AspNetUsers_ApplicationUserId",
                table: "Promotions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
