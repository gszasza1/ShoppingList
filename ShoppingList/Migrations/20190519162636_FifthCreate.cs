using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCounters_FridgeList_FridgeListId",
                table: "FoodCounters");

            migrationBuilder.DropTable(
                name: "FridgeList");

            migrationBuilder.DropIndex(
                name: "IX_FoodCounters_FridgeListId",
                table: "FoodCounters");

            migrationBuilder.DropColumn(
                name: "FridgeListId",
                table: "FoodCounters");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Foods",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Foods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 19, 18, 26, 36, 47, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 15, 20, 44, 33, 542, DateTimeKind.Local));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BuyList",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    creation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FoodId",
                table: "Messages",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BuyList");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "FoodCounters",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 15, 20, 44, 33, 542, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 19, 18, 26, 36, 47, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "FridgeListId",
                table: "FoodCounters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FridgeList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodCounters_FridgeListId",
                table: "FoodCounters",
                column: "FridgeListId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCounters_FridgeList_FridgeListId",
                table: "FoodCounters",
                column: "FridgeListId",
                principalTable: "FridgeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
