using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCocktails.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFamily : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientLines_Families_FamilyId",
                table: "IngredientLines");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropIndex(
                name: "IX_IngredientLines_FamilyId",
                table: "IngredientLines");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "IngredientLines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "IngredientLines",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FamilyId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Families_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientLines_FamilyId",
                table: "IngredientLines",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_FamilyId",
                table: "Families",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientLines_Families_FamilyId",
                table: "IngredientLines",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }
    }
}
