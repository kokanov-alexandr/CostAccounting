using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostAccounting.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryIdToPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Purchases",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Purchases");
        }
    }
}
