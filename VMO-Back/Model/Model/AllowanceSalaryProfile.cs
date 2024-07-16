using Model.Utils;
using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class AllowanceSalaryProfile
    {
        [Key]
        public string AllowanceSalaryProfileId { get; set; }
        public string AllowanceId { get; set; }
        public Allowance? Allowance { get; set; }
        public string SalaryProfileId { get; set; }
        public SalaryProfile? SalaryProfile { get; set; }
        public DateTime CreateDate { get; set; }
        public ActiveStatus Status { get; set; }
    }
}