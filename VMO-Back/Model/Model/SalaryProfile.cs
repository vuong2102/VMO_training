using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class SalaryProfile
    {
        public string SalaryProfileId { get; set; }
        public int BasicSalary { get; set; }
        public int Bonus { get; set; }
        public int Deduction { get; set; }
        public int NetSalary { get; set; }
        public int GrossSalary { get; set; }
        public string SalaryRank { get; set; }
        public string SalaryLevel { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdaterId { get; set; }
        public ActiveStatus Status { get; set; }

        //Relationship
        public string? ContractId { get; set; }
        public Contract Contract { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<BenefitSalaryProfile>? BenefitSalaryProfiles { get; set; } = new List<BenefitSalaryProfile>();
        public ICollection<AllowanceSalaryProfile>? AllowanceSalaryProfiles { get; set; } = new List<AllowanceSalaryProfile>();
    }
}
