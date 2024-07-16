using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMO_Back.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    BenefitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefit", x => x.BenefitId);
                });

            migrationBuilder.CreateTable(
                name: "ContractType",
                columns: table => new
                {
                    ContractTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractType", x => x.ContractTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentType = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryProfile",
                columns: table => new
                {
                    SalaryProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BasicSalary = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: false),
                    Deduction = table.Column<int>(type: "int", nullable: false),
                    NetSalary = table.Column<int>(type: "int", nullable: false),
                    SalaryRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdaterId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryProfile", x => x.SalaryProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                    table.ForeignKey(
                        name: "FK_Title_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allowance",
                columns: table => new
                {
                    AllowanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SalaryProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowance", x => x.AllowanceId);
                    table.ForeignKey(
                        name: "FK_Allowance_SalaryProfile_SalaryProfileId",
                        column: x => x.SalaryProfileId,
                        principalTable: "SalaryProfile",
                        principalColumn: "SalaryProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitSalaryProfiles",
                columns: table => new
                {
                    BenefitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SalaryProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BenefitSalaryProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitSalaryProfiles", x => new { x.BenefitId, x.SalaryProfileId });
                    table.ForeignKey(
                        name: "FK_BenefitSalaryProfiles_Benefit_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefit",
                        principalColumn: "BenefitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitSalaryProfiles_SalaryProfile_SalaryProfileId",
                        column: x => x.SalaryProfileId,
                        principalTable: "SalaryProfile",
                        principalColumn: "SalaryProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_Employee_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId");
                });

            migrationBuilder.CreateTable(
                name: "AllocatedAssets",
                columns: table => new
                {
                    AllocatedAssetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DateAllocated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusAsset = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocatedAssets", x => x.AllocatedAssetId);
                    table.ForeignKey(
                        name: "FK_AllocatedAssets_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSign = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdaterId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SalaryProfileId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_ContractType_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractType",
                        principalColumn: "ContractTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_SalaryProfile_SalaryProfileId",
                        column: x => x.SalaryProfileId,
                        principalTable: "SalaryProfile",
                        principalColumn: "SalaryProfileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllocatedAssets_EmployeeId",
                table: "AllocatedAssets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_SalaryProfileId",
                table: "Allowance",
                column: "SalaryProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitSalaryProfiles_SalaryProfileId",
                table: "BenefitSalaryProfiles",
                column: "SalaryProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractTypeId",
                table: "Contract",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_EmployeeId",
                table: "Contract",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_SalaryProfileId",
                table: "Contract",
                column: "SalaryProfileId",
                unique: true,
                filter: "[SalaryProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TitleId",
                table: "Employee",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_DepartmentId",
                table: "Title",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllocatedAssets");

            migrationBuilder.DropTable(
                name: "Allowance");

            migrationBuilder.DropTable(
                name: "BenefitSalaryProfiles");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "ContractType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "SalaryProfile");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
