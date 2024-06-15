using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrelloProjekt.Migrations
{
    /// <inheritdoc />
    public partial class Title : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Todo");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Todo",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "User",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todo",
                newName: "Text");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Todo",
                type: "TEXT",
                nullable: true);
        }
    }
}
