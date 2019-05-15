using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCounters_ShoppinsdgList_BuyListId",
                table: "FoodCounters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppinsdgList",
                table: "ShoppinsdgList");

            migrationBuilder.RenameTable(
                name: "ShoppinsdgList",
                newName: "BuyList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyList",
                table: "BuyList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCounters_BuyList_BuyListId",
                table: "FoodCounters",
                column: "BuyListId",
                principalTable: "BuyList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCounters_BuyList_BuyListId",
                table: "FoodCounters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyList",
                table: "BuyList");

            migrationBuilder.RenameTable(
                name: "BuyList",
                newName: "ShoppinsdgList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppinsdgList",
                table: "ShoppinsdgList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCounters_ShoppinsdgList_BuyListId",
                table: "FoodCounters",
                column: "BuyListId",
                principalTable: "ShoppinsdgList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
