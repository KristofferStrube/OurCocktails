using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCocktails.Migrations
{
    /// <inheritdoc />
    public partial class MadeIngredientRequiredOnLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientLines_Ingredients_IngredientId",
                table: "IngredientLines");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "IngredientLines",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientLines_Ingredients_IngredientId",
                table: "IngredientLines",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientLines_Ingredients_IngredientId",
                table: "IngredientLines");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "IngredientLines",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientLines_Ingredients_IngredientId",
                table: "IngredientLines",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }
    }
}
