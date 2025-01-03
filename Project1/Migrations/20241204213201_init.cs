using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPasword",
                table: "UserAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Phonenumber",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phonenumber",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPasword",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
