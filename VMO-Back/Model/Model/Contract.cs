using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Contract
    {
        [Key]
        public string ContractId { get; set; }
        public string ContractCode { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public int StatusSign { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdaterId { get; set; }
        public int Status { get; set; }

        //Relationship
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string ContractTypeId { get; set; }
        public ContractType ContractType { get; set; }
        public string? SalaryProfileId { get; set; }
        public SalaryProfile? SalaryProfile { get; set; }


    }
}
