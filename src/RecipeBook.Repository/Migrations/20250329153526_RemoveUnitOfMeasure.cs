using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBook.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnitOfMeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitOfMeasurementId",
                table: "MeasurementSystem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasurementId",
                table: "MeasurementSystem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
