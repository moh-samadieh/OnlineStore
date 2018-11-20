using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Data.Migrations
{
    public partial class parentid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducts_Categories_CategoryID",
                schema: "dbo",
                table: "CategoryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConfigs_Products_ProductID",
                schema: "dbo",
                table: "ProductConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConfigs_Sellers_SellerID",
                schema: "dbo",
                table: "ProductConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandID",
                schema: "dbo",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BrandID",
                schema: "dbo",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerID",
                schema: "dbo",
                table: "ProductConfigs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                schema: "dbo",
                table: "ProductConfigs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                schema: "dbo",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                schema: "dbo",
                table: "CategoryProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducts_Categories_CategoryID",
                schema: "dbo",
                table: "CategoryProducts",
                column: "CategoryID",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                schema: "dbo",
                table: "OrderItems",
                column: "ProductID",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConfigs_Products_ProductID",
                schema: "dbo",
                table: "ProductConfigs",
                column: "ProductID",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConfigs_Sellers_SellerID",
                schema: "dbo",
                table: "ProductConfigs",
                column: "SellerID",
                principalSchema: "dbo",
                principalTable: "Sellers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                schema: "dbo",
                table: "Products",
                column: "BrandID",
                principalSchema: "dbo",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducts_Categories_CategoryID",
                schema: "dbo",
                table: "CategoryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConfigs_Products_ProductID",
                schema: "dbo",
                table: "ProductConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConfigs_Sellers_SellerID",
                schema: "dbo",
                table: "ProductConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandID",
                schema: "dbo",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BrandID",
                schema: "dbo",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SellerID",
                schema: "dbo",
                table: "ProductConfigs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                schema: "dbo",
                table: "ProductConfigs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                schema: "dbo",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                schema: "dbo",
                table: "CategoryProducts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducts_Categories_CategoryID",
                schema: "dbo",
                table: "CategoryProducts",
                column: "CategoryID",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                schema: "dbo",
                table: "OrderItems",
                column: "ProductID",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConfigs_Products_ProductID",
                schema: "dbo",
                table: "ProductConfigs",
                column: "ProductID",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConfigs_Sellers_SellerID",
                schema: "dbo",
                table: "ProductConfigs",
                column: "SellerID",
                principalSchema: "dbo",
                principalTable: "Sellers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                schema: "dbo",
                table: "Products",
                column: "BrandID",
                principalSchema: "dbo",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
