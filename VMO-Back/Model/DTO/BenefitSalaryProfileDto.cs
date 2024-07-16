using Model.Model;
using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class BenefitSalaryProfileDto
    {
        public string BenefitSalaryProfileId { get; set; }
        public string BenefitId { get; set; }
        public Benefit Benefit { get; set; }
        public string SalaryProfileId { get; set; }
        public SalaryProfile SalaryProfile { get; set; }
        public DateTime CreateDate { get; set; }
        public ActiveStatus Status { get; set; }
    }

    public class BenefitSalaryProfileAddDto
    {
        public Benefit Benefit { get; set; }
        public DateTime CreateDate { get; set; }
        public ActiveStatus Status { get; set; }
    }

    public class BenefitSalaryProfileUpdateDto
    {
        public string BenefitSalaryProfileId { get; set; }
        public string BenefitId { get; set; }
        public Benefit Benefit { get; set; }
        public string SalaryProfileId { get; set; }
        public SalaryProfile SalaryProfile { get; set; }
        public DateTime CreateDate { get; set; }
        public ActiveStatus Status { get; set; }
    }
}
