using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMO_Back.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalaryProfile_EmployeeId",
                table: "SalaryProfile");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryProfile_EmployeeId",
                table: "SalaryProfile",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalaryProfile_EmployeeId",
                table: "SalaryProfile");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryProfile_EmployeeId",
                table: "SalaryProfile",
                column: "EmployeeId");
        }
    }
}
