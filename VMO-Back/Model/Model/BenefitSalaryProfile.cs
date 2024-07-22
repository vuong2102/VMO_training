using Model.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class BenefitSalaryProfile
    {
        [Key]
        public string BenefitSalaryProfileId { get; set; }
        public string BenefitId { get; set; }
        public Benefit? Benefit { get; set; }
        public string SalaryProfileId { get; set; }
        public SalaryProfile? SalaryProfile { get; set; }
        public DateTime CreateDate { get; set; }
        public ActiveStatus Status { get; set; }

    }
}
