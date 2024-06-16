using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modul6_EF_NoLostData.Migrations
{
    /// <inheritdoc />
    public partial class NameAndCategoryToTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                            name: "Title",
                            table: "Todo",
                            nullable: true);

            migrationBuilder.Sql(
                @"UPDATE Todo
                    SET Title = Category || ':' || Name;;
                    ");

            // TODO: Drop de to gamle kolonner
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Todo");

            migrationBuilder.DropColumn(
            name: "Category",
            table: "Todo");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todo",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Todo",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
