using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Foods_FoodId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "FoodMessageRating");

            migrationBuilder.RenameColumn(
                name: "creation",
                table: "FoodMessageRating",
                newName: "Creation");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "FoodMessageRating",
                newName: "Stars");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FoodId",
                table: "FoodMessageRating",
                newName: "IX_FoodMessageRating_FoodId");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Foods",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 20, 20, 14, 39, 823, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 19, 18, 26, 36, 47, DateTimeKind.Local));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "FoodCounters",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "BuyList",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodMessageRating",
                table: "FoodMessageRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMessageRating_Foods_FoodId",
                table: "FoodMessageRating",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMessageRating_Foods_FoodId",
                table: "FoodMessageRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodMessageRating",
                table: "FoodMessageRating");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "FoodCounters");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "BuyList");

            migrationBuilder.RenameTable(
                name: "FoodMessageRating",
                newName: "Messages");

            migrationBuilder.RenameColumn(
                name: "Creation",
                table: "Messages",
                newName: "creation");

            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "Messages",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_FoodMessageRating_FoodId",
                table: "Messages",
                newName: "IX_Messages_FoodId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 19, 18, 26, 36, 47, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 20, 20, 14, 39, 823, DateTimeKind.Local));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Foods_FoodId",
                table: "Messages",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
