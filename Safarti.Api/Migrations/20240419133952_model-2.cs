using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safarti.Api.Migrations
{
    /// <inheritdoc />
    public partial class model2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Profiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Profiles",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
