using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodStoreApp.Migrations
{
    public partial class OneToManyForProductAndFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UserFiles_UserFileId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserFileId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserFileId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "UserFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "UserFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_ProductsId",
                table: "UserFiles",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFiles_Products_ProductsId",
                table: "UserFiles",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_Products_ProductsId",
                table: "UserFiles");

            migrationBuilder.DropIndex(
                name: "IX_UserFiles_ProductsId",
                table: "UserFiles");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UserFiles");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "UserFiles");

            migrationBuilder.AddColumn<int>(
                name: "UserFileId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserFileId",
                table: "Products",
                column: "UserFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UserFiles_UserFileId",
                table: "Products",
                column: "UserFileId",
                principalTable: "UserFiles",
                principalColumn: "Id");
        }
    }
}
