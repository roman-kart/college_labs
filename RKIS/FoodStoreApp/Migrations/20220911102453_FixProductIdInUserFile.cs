using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodStoreApp.Migrations
{
    public partial class FixProductIdInUserFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_Products_ProductsId",
                table: "UserFiles");

            migrationBuilder.DropIndex(
                name: "IX_UserFiles_ProductsId",
                table: "UserFiles");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "UserFiles");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "UserFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_ProductId",
                table: "UserFiles",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFiles_Products_ProductId",
                table: "UserFiles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_Products_ProductId",
                table: "UserFiles");

            migrationBuilder.DropIndex(
                name: "IX_UserFiles_ProductId",
                table: "UserFiles");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "UserFiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
