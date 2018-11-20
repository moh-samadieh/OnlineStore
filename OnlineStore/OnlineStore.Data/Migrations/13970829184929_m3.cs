using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Data.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducts_Products_ProductID",
                schema: "dbo",
                table: "CategoryProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                schema: "dbo",
                table: "CategoryProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducts_Products_ProductID",
                schema: "dbo",
                table: "CategoryProducts",
                column: "ProductID",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducts_Products_ProductID",
                schema: "dbo",
                table: "CategoryProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                schema: "dbo",
                table: "CategoryProducts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducts_Products_ProductID",
                schema: "dbo",
                table: "CategoryProducts",
                column: "ProductID",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
