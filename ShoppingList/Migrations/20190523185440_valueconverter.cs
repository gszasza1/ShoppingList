using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class valueconverter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 23, 20, 54, 39, 986, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 21, 21, 47, 9, 283, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 21, 21, 47, 9, 283, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 23, 20, 54, 39, 986, DateTimeKind.Local));
        }
    }
}
