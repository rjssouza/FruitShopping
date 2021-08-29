using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fruit.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FruitInventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FruitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitInventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sell",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sell", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fruit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fruit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fruit_FruitInventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "FruitInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FruitPicture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FruitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FruitPicture_Fruit_FruitId",
                        column: x => x.FruitId,
                        principalTable: "Fruit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FruitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SellId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellItem_Fruit_SellId",
                        column: x => x.SellId,
                        principalTable: "Fruit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellItem_Sell_SellId",
                        column: x => x.SellId,
                        principalTable: "Sell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_InventoryId",
                table: "Fruit",
                column: "InventoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FruitPicture_FruitId",
                table: "FruitPicture",
                column: "FruitId");

            migrationBuilder.CreateIndex(
                name: "IX_SellItem_SellId",
                table: "SellItem",
                column: "SellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FruitPicture");

            migrationBuilder.DropTable(
                name: "SellItem");

            migrationBuilder.DropTable(
                name: "Fruit");

            migrationBuilder.DropTable(
                name: "Sell");

            migrationBuilder.DropTable(
                name: "FruitInventory");
        }
    }
}
