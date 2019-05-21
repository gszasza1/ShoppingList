using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class addedownedtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "BuyList",
                newName: "CreationBuylist_OrderDate");

            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "BuyList",
                newName: "CreationBuylist_Creator");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 21, 21, 47, 9, 283, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 20, 22, 24, 13, 819, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationBuylist_OrderDate",
                table: "BuyList",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "CreationBuylist_Creator",
                table: "BuyList",
                newName: "Creator");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 20, 22, 24, 13, 819, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 21, 21, 47, 9, 283, DateTimeKind.Local));
        }
    }
}
