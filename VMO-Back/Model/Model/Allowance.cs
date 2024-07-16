using Model.Utils;
using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Allowance
    {
        [Key]
        public virtual string AllowanceId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Amount { get; set; }
        public ActiveStatus Status { get; set; }
        public ICollection<AllowanceSalaryProfile>? AllowanceSalaryProfiles { get; set; }
    }
}
