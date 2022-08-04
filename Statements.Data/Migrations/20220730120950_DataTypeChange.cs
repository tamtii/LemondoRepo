using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Statements.Data.Migrations
{
    public partial class DataTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Statements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Statements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
