using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewTempName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temp",
                table: "MockDataSets");

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "MockDataSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "MockDataSets");

            migrationBuilder.AddColumn<string>(
                name: "Temp",
                table: "MockDataSets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
