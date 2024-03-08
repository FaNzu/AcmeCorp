using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcmeCorp.Web.Api.Migrations
{
    /// <inheritdoc />
    public partial class drawentryuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrawNumberUses",
                table: "DrawEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrawNumberUses",
                table: "DrawEntries");
        }
    }
}
