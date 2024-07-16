using Model.Model;
using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AllowanceSalaryProfileDto
    {
        public string AllowanceSalaryProfileId { get; set; }
        public string AllowanceId { get; set; }
        public Allowance Allowance { get; set; }
        public string SalaryProfileId { get; set; }
        public SalaryProfile SalaryProfile { get; set; }
        public DateTime CreateDate { get; set; }
        public ActiveStatus Status { get; set; }
    }

    public class AllowanceSalaryProfileAddDto
    {
        public Allowance Allowance { get; set; }
        public string SalaryProfileId { get; set; }
        public SalaryProfile SalaryProfile { get; set; }
        public DateTime CreateDate { get; set; }
        public ActiveStatus Status { get; set; }
    }
    
    public class AllowanceSalaryProfileUpdateDto
    {
        public string AllowanceSalaryProfileId { get; set; }
        public Allowance Allowance { get; set; }
        public string SalaryProfileId { get; set; }
        public SalaryProfile SalaryProfile { get; set; }
        public DateTime CreateDate { get; set; }
        public ActiveStatus Status { get; set; }
    }
}
