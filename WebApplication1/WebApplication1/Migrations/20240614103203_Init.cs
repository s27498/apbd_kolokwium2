using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    current_weig = table.Column<int>(type: "int", nullable: false),
                    max_weight = table.Column<int>(type: "int", nullable: false),
                    money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weig = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Backpack_Slots",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_item = table.Column<int>(type: "int", nullable: false),
                    FK_character = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpack_Slots", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Backpack_Slots_Characters_FK_character",
                        column: x => x.FK_character,
                        principalTable: "Characters",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpack_Slots_Items_FK_item",
                        column: x => x.FK_item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters_Titles",
                columns: table => new
                {
                    FK_charact = table.Column<int>(type: "int", nullable: false),
                    FK_title = table.Column<int>(type: "int", nullable: false),
                    aquire_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters_Titles", x => new { x.FK_charact, x.FK_title });
                    table.ForeignKey(
                        name: "FK_Characters_Titles_Characters_FK_charact",
                        column: x => x.FK_charact,
                        principalTable: "Characters",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Titles_Titles_FK_title",
                        column: x => x.FK_title,
                        principalTable: "Titles",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "PK", "current_weig", "first_name", "last_name", "max_weight", "money" },
                values: new object[,]
                {
                    { 1, 10, "Jan", "Kowal", 50, 100 },
                    { 2, 5, "Piotr", "Dzwon", 45, 150 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Weig" },
                values: new object[,]
                {
                    { 1, "Miecz", 5 },
                    { 2, "Tarcza", 7 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "PK", "nam" },
                values: new object[,]
                {
                    { 1, "Wojownik" },
                    { 2, "Mag" }
                });

            migrationBuilder.InsertData(
                table: "Backpack_Slots",
                columns: new[] { "PK", "FK_character", "FK_item" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Characters_Titles",
                columns: new[] { "FK_charact", "FK_title", "aquire_at" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 14, 12, 32, 2, 794, DateTimeKind.Local).AddTicks(8332) },
                    { 2, 2, new DateTime(2024, 6, 14, 12, 32, 2, 794, DateTimeKind.Local).AddTicks(8373) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_FK_character",
                table: "Backpack_Slots",
                column: "FK_character");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_FK_item",
                table: "Backpack_Slots",
                column: "FK_item");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Titles_FK_title",
                table: "Characters_Titles",
                column: "FK_title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpack_Slots");

            migrationBuilder.DropTable(
                name: "Characters_Titles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
