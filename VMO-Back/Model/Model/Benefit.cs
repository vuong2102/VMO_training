using Model.Utils;
using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Benefit
    {
        [Key]
        public virtual string BenefitId { get; set; }
        public virtual string Type { get; set; }
        public virtual int Expense { get; set; }
        public ActiveStatus Status { get; set; }
        public ICollection<BenefitSalaryProfile>? BenefitSalaryProfiles { get; set; }
    }
}