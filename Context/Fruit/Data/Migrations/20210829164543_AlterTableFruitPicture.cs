using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fruit.Data.Migrations
{
    public partial class AlterTableFruitPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "FruitPicture");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "FruitPicture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "FruitPicture");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "FruitPicture",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
