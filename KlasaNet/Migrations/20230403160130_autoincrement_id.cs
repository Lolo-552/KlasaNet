using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlasaNet.Migrations
{
    /// <inheritdoc />
    public partial class autoincrement_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Directors");
        }
    }
}
