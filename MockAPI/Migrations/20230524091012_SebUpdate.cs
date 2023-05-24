using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockAPI.Migrations
{
    /// <inheritdoc />
    public partial class SebUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Temperature",
                table: "MockDataSets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "double");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "MockDataSets",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
