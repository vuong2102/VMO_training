using Model.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ContractTypeDto
    {
        public string ContractTypeId { get; set; }
        public string Name { get; set; }
        public string ContractCode { get; set; }
        public int Term { get; set; }
        public ActiveStatus Status { get; set; }
    }
    public class ContractTypeAddDto
    {
        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string ContractCode { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public int Term { get; set; }
        public ActiveStatus Status { get; set; }
    }
    public class ContractTypeUpdateDto
    {
        public string ContractTypeId { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string ContractCode { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public int Term { get; set; }
        public ActiveStatus Status { get; set; }
    }
}
