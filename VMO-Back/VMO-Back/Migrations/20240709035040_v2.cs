using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMO_Back.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Employee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractId",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
