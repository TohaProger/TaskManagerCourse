using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerCourse.Api.Migrations
{
    /// <inheritdoc />
    public partial class dropPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);*/
        }
    }
}
