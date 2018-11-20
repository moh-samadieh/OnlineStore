using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Data.Migrations
{
    public partial class brandnamefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CaFategoryParentID",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CaFategoryParentID",
                schema: "dbo",
                table: "Categories",
                newName: "CategoryParentID");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CaFategoryParentID",
                schema: "dbo",
                table: "Categories",
                newName: "IX_Categories_CategoryParentID");

            migrationBuilder.AddColumn<string>(
                name: "NameFa",
                schema: "dbo",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryParentID",
                schema: "dbo",
                table: "Categories",
                column: "CategoryParentID",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryParentID",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameFa",
                schema: "dbo",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "CategoryParentID",
                schema: "dbo",
                table: "Categories",
                newName: "CaFategoryParentID");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoryParentID",
                schema: "dbo",
                table: "Categories",
                newName: "IX_Categories_CaFategoryParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CaFategoryParentID",
                schema: "dbo",
                table: "Categories",
                column: "CaFategoryParentID",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
