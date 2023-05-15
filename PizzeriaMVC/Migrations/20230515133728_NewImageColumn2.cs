using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaMVC.Migrations
{
    /// <inheritdoc />
    public partial class NewImageColumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_ImageEntries_ImageEntryId",
                table: "pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "ImageEntryId",
                table: "pizzas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_ImageEntries_ImageEntryId",
                table: "pizzas",
                column: "ImageEntryId",
                principalTable: "ImageEntries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_ImageEntries_ImageEntryId",
                table: "pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "ImageEntryId",
                table: "pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_ImageEntries_ImageEntryId",
                table: "pizzas",
                column: "ImageEntryId",
                principalTable: "ImageEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
