using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoKeeper.Infrastructure.Database.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class ItemAndTagManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Items_ItemId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ItemId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Tags");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 21, 20, 59, 0, 104, DateTimeKind.Local).AddTicks(5995),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 3, 21, 20, 18, 48, 275, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.CreateTable(
                name: "ItemTag",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTag", x => new { x.ItemsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ItemTag_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_TagsId",
                table: "ItemTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTag");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime(6)",
                nullable: true,
                defaultValue: new DateTime(2023, 3, 21, 20, 18, 48, 275, DateTimeKind.Local).AddTicks(1520),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 21, 20, 59, 0, 104, DateTimeKind.Local).AddTicks(5995));

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemId",
                table: "Tags",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Items_ItemId",
                table: "Tags",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
