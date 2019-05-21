using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 20, 22, 24, 13, 819, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 20, 20, 14, 39, 823, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UnitPrice",
                table: "Foods",
                column: "UnitPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Foods_UnitPrice",
                table: "Foods");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 20, 20, 14, 39, 823, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 20, 22, 24, 13, 819, DateTimeKind.Local));
        }
    }
}
