using Model.Model;
using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class SalaryProfileDto
    {
        public string SalaryProfileId { get; set; }
        public int BasicSalary { get; set; }
        public int Bonus { get; set; }
        public int Deduction { get; set; }
        public int NetSalary { get; set; }
        public string SalaryRank { get; set; }
        public string SalaryLevel { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdaterId { get; set; }
        public ActiveStatus Status { get; set; }

        //Relationship
        public string? ContractId { get; set; }
        public string EmployeeId{ get; set; }
        public ICollection<Benefit>? Benefits { get; set; }
        public ICollection<Allowance>? Allowances { get; set; }
    }
    public class SalaryProfileAddDto
    {
        public int BasicSalary { get; set; }
        public int Bonus { get; set; }
        public int Deduction { get; set; }
        public int NetSalary { get; set; }
        public string SalaryRank { get; set; }
        public string SalaryLevel { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdaterId { get; set; }
        public ActiveStatus Status { get; set; }
        public string? ContractId { get; set; }
        public string EmployeeId { get; set; }

        public ICollection<BenefitDto>? Benefits { get; set; }
        public ICollection<AllowanceDto>? Allowances { get; set; }
    }

    public class SalaryProfileUpdateDto
    {
        public int BasicSalary { get; set; }
        public int Bonus { get; set; }
        public int Deduction { get; set; }
        public int NetSalary { get; set; }
        public string SalaryRank { get; set; }
        public string SalaryLevel { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdaterId { get; set; }
        public ActiveStatus Status { get; set; }
        public string? ContractId { get; set; }
        public string EmployeeId { get; set; }

        public ICollection<BenefitSalaryProfile> BenefitSalaryProfiles { get; set; }
        public ICollection<AllowanceSalaryProfile> AllowanceSalaryProfiles { get; set; }
    }
}
