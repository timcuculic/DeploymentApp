using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeploymentApp.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExponseTypeId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExpenseTypes",
                newName: "ExpenseTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseTypeId",
                table: "ExpenseTypes",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ExponseTypeId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
