using Microsoft.EntityFrameworkCore.Migrations;

namespace Fruit.Data.Migrations
{
    public partial class CorrecaoFkCartFruit_Key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Fruit_CartId",
                table: "CartItem");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_FruitId",
                table: "CartItem",
                column: "FruitId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Fruit_FruitId",
                table: "CartItem",
                column: "FruitId",
                principalTable: "Fruit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Fruit_FruitId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_FruitId",
                table: "CartItem");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Fruit_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Fruit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
