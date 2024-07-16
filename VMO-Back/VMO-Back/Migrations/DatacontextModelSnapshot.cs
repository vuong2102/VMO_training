﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VMO_Back;

#nullable disable

namespace VMO_Back.Migrations
{
    [DbContext(typeof(Datacontext))]
    partial class DatacontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Model.AllocatedAssets", b =>
                {
                    b.Property<string>("AllocatedAssetId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAllocated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusAsset")
                        .HasColumnType("int");

                    b.HasKey("AllocatedAssetId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("AllocatedAssets");
                });

            modelBuilder.Entity("Model.Model.Allowance", b =>
                {
                    b.Property<string>("AllowanceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AllowanceId");

                    b.ToTable("Allowance");
                });

            modelBuilder.Entity("Model.Model.AllowanceSalaryProfile", b =>
                {
                    b.Property<string>("AllowanceSalaryProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllowanceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SalaryProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AllowanceSalaryProfileId");

                    b.HasIndex("AllowanceId");

                    b.HasIndex("SalaryProfileId");

                    b.ToTable("AllowanceSalaryProfile");
                });

            modelBuilder.Entity("Model.Model.Benefit", b =>
                {
                    b.Property<string>("BenefitId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Expense")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BenefitId");

                    b.ToTable("Benefit");
                });

            modelBuilder.Entity("Model.Model.BenefitSalaryProfile", b =>
                {
                    b.Property<string>("BenefitId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SalaryProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BenefitSalaryProfileId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("BenefitId", "SalaryProfileId");

                    b.HasIndex("SalaryProfileId");

                    b.ToTable("BenefitSalaryProfiles");
                });

            modelBuilder.Entity("Model.Model.Contract", b =>
                {
                    b.Property<string>("ContractId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContractCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SalaryProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusSign")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContractId");

                    b.HasIndex("ContractTypeId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("SalaryProfileId")
                        .IsUnique()
                        .HasFilter("[SalaryProfileId] IS NOT NULL");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Model.Model.ContractType", b =>
                {
                    b.Property<string>("ContractTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContractCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("ContractTypeId");

                    b.ToTable("ContractType");
                });

            modelBuilder.Entity("Model.Model.Department", b =>
                {
                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Model.Model.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TitleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("TitleId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Model.Model.SalaryProfile", b =>
                {
                    b.Property<string>("SalaryProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BasicSalary")
                        .HasColumnType("int");

                    b.Property<int>("Bonus")
                        .HasColumnType("int");

                    b.Property<string>("ContractId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Deduction")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NetSalary")
                        .HasColumnType("int");

                    b.Property<string>("SalaryLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalaryRank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdaterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalaryProfileId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("SalaryProfile");
                });

            modelBuilder.Entity("Model.Model.Title", b =>
                {
                    b.Property<string>("TitleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TitleCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TitleId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("Model.Model.AllocatedAssets", b =>
                {
                    b.HasOne("Model.Model.Employee", "Employee")
                        .WithMany("AllocatedAssets")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Model.Model.AllowanceSalaryProfile", b =>
                {
                    b.HasOne("Model.Model.Allowance", "Allowance")
                        .WithMany("AllowanceSalaryProfiles")
                        .HasForeignKey("AllowanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Model.SalaryProfile", "SalaryProfile")
                        .WithMany("AllowanceSalaryProfiles")
                        .HasForeignKey("SalaryProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allowance");

                    b.Navigation("SalaryProfile");
                });

            modelBuilder.Entity("Model.Model.BenefitSalaryProfile", b =>
                {
                    b.HasOne("Model.Model.Benefit", "Benefit")
                        .WithMany("BenefitSalaryProfiles")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Model.SalaryProfile", "SalaryProfile")
                        .WithMany("BenefitSalaryProfiles")
                        .HasForeignKey("SalaryProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("SalaryProfile");
                });

            modelBuilder.Entity("Model.Model.Contract", b =>
                {
                    b.HasOne("Model.Model.ContractType", "ContractType")
                        .WithMany("Contracts")
                        .HasForeignKey("ContractTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Model.Employee", "Employee")
                        .WithOne("Contract")
                        .HasForeignKey("Model.Model.Contract", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Model.SalaryProfile", "SalaryProfile")
                        .WithOne("Contract")
                        .HasForeignKey("Model.Model.Contract", "SalaryProfileId");

                    b.Navigation("ContractType");

                    b.Navigation("Employee");

                    b.Navigation("SalaryProfile");
                });

            modelBuilder.Entity("Model.Model.Employee", b =>
                {
                    b.HasOne("Model.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Model.Model.Title", "Title")
                        .WithMany("Employees")
                        .HasForeignKey("TitleId");

                    b.Navigation("Department");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Model.Model.SalaryProfile", b =>
                {
                    b.HasOne("Model.Model.Employee", "Employee")
                        .WithOne("SalaryProfile")
                        .HasForeignKey("Model.Model.SalaryProfile", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Model.Model.Title", b =>
                {
                    b.HasOne("Model.Model.Department", "Department")
                        .WithMany("Titles")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Model.Model.Allowance", b =>
                {
                    b.Navigation("AllowanceSalaryProfiles");
                });

            modelBuilder.Entity("Model.Model.Benefit", b =>
                {
                    b.Navigation("BenefitSalaryProfiles");
                });

            modelBuilder.Entity("Model.Model.ContractType", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Model.Model.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Titles");
                });

            modelBuilder.Entity("Model.Model.Employee", b =>
                {
                    b.Navigation("AllocatedAssets");

                    b.Navigation("Contract");

                    b.Navigation("SalaryProfile");
                });

            modelBuilder.Entity("Model.Model.SalaryProfile", b =>
                {
                    b.Navigation("AllowanceSalaryProfiles");

                    b.Navigation("BenefitSalaryProfiles");

                    b.Navigation("Contract")
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Model.Title", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
