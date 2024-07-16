using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMO_Back.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowance_SalaryProfile_SalaryProfileId",
                table: "Allowance");

            migrationBuilder.DropIndex(
                name: "IX_Allowance_SalaryProfileId",
                table: "Allowance");

            migrationBuilder.DropColumn(
                name: "SalaryProfileId",
                table: "Allowance");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "BenefitSalaryProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BenefitSalaryProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Benefit",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Expense",
                table: "Benefit",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Allowance",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AllowanceSalaryProfile",
                columns: table => new
                {
                    AllowanceSalaryProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SalaryProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowanceSalaryProfile", x => x.AllowanceSalaryProfileId);
                    table.ForeignKey(
                        name: "FK_AllowanceSalaryProfile_Allowance_AllowanceId",
                        column: x => x.AllowanceId,
                        principalTable: "Allowance",
                        principalColumn: "AllowanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllowanceSalaryProfile_SalaryProfile_SalaryProfileId",
                        column: x => x.SalaryProfileId,
                        principalTable: "SalaryProfile",
                        principalColumn: "SalaryProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceSalaryProfile_AllowanceId",
                table: "AllowanceSalaryProfile",
                column: "AllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceSalaryProfile_SalaryProfileId",
                table: "AllowanceSalaryProfile",
                column: "SalaryProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowanceSalaryProfile");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "BenefitSalaryProfiles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BenefitSalaryProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Benefit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Expense",
                table: "Benefit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Allowance",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "SalaryProfileId",
                table: "Allowance",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_SalaryProfileId",
                table: "Allowance",
                column: "SalaryProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowance_SalaryProfile_SalaryProfileId",
                table: "Allowance",
                column: "SalaryProfileId",
                principalTable: "SalaryProfile",
                principalColumn: "SalaryProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
