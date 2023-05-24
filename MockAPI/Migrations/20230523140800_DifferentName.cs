using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockAPI.Migrations
{
    /// <inheritdoc />
    public partial class DifferentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MockDatas",
                table: "MockDatas");

            migrationBuilder.RenameTable(
                name: "MockDatas",
                newName: "MockDataSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MockDataSet",
                table: "MockDataSet",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MockDataSet",
                table: "MockDataSet");

            migrationBuilder.RenameTable(
                name: "MockDataSet",
                newName: "MockDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MockDatas",
                table: "MockDatas",
                column: "Id");
        }
    }
}
