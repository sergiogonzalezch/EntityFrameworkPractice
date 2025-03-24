using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fundamentos_Entity_Framework_C_.Migrations
{
    /// <inheritdoc />
    public partial class ColumnTimeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Category");
        }
    }
}
