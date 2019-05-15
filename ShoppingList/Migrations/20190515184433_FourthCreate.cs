using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCounters_BuyList_BuyListId",
                table: "FoodCounters");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCounters_Foods_FoodsId",
                table: "FoodCounters");

            migrationBuilder.DropIndex(
                name: "IX_FoodCounters_FoodsId",
                table: "FoodCounters");

            migrationBuilder.DropColumn(
                name: "FoodsId",
                table: "FoodCounters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 15, 20, 44, 33, 542, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "BuyListId",
                table: "FoodCounters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "FoodCounters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCounters_FoodId",
                table: "FoodCounters",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCounters_BuyList_BuyListId",
                table: "FoodCounters",
                column: "BuyListId",
                principalTable: "BuyList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCounters_Foods_FoodId",
                table: "FoodCounters",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCounters_BuyList_BuyListId",
                table: "FoodCounters");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCounters_Foods_FoodId",
                table: "FoodCounters");

            migrationBuilder.DropIndex(
                name: "IX_FoodCounters_FoodId",
                table: "FoodCounters");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "FoodCounters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 15, 20, 44, 33, 542, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "BuyListId",
                table: "FoodCounters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FoodsId",
                table: "FoodCounters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCounters_FoodsId",
                table: "FoodCounters",
                column: "FoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCounters_BuyList_BuyListId",
                table: "FoodCounters",
                column: "BuyListId",
                principalTable: "BuyList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCounters_Foods_FoodsId",
                table: "FoodCounters",
                column: "FoodsId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
