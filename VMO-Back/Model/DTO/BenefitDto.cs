using Model.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class BenefitDto
    {
        public string BenefitId { get; set; }
        public string Type { get; set; }
        public int Expense { get; set; }
        public ActiveStatus Status { get; set; }
    }

    public class BenefitAddDto
    {
        [Required(ErrorMessage = "You must enter {0}")]
        public string Type { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public Decimal Expense { get; set; }

        [Required]
        public ActiveStatus Status { get; set; }
    }

    public class BenefitUpdateDto
    {
        public string Type { get; set; }
        public Decimal Expense { get; set; }
        public int Status { get; set; }
    }
}
