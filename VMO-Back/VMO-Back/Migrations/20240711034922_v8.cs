using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMO_Back.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "SalaryProfile",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryProfile_EmployeeId",
                table: "SalaryProfile",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryProfile_Employee_EmployeeId",
                table: "SalaryProfile",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryProfile_Employee_EmployeeId",
                table: "SalaryProfile");

            migrationBuilder.DropIndex(
                name: "IX_SalaryProfile_EmployeeId",
                table: "SalaryProfile");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SalaryProfile");
        }
    }
}
