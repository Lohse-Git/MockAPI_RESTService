using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockAPI.Migrations
{
    /// <inheritdoc />
    public partial class FloatAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "MockDataSets",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "MockDataSets",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "double");
        }
    }
}
