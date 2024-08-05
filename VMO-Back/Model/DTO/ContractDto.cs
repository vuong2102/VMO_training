using Model.Model;
using Model.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ContractDto
    {
        public string ContractId { get; set; }
        public string ContractCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StatusSign StatusSign { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdaterId { get; set; }
        public ActiveStatus Status { get; set; }

        //Relationship
        public string EmployeeId { get; set; }
        public string ContractTypeId { get; set; }
        public string? SalaryProfileId { get; set; }
    }

    public class ContractAddDto
    {
        [Required(ErrorMessage = "You must enter {0}")]
        public string ContractCode { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public StatusSign StatusSign { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdaterId { get; set; }
        public ActiveStatus Status { get; set; }
        public string EmployeeId { get; set; }
        public string ContractTypeId { get; set; }
        public string? SalaryProfileId { get; set; }
    }

    public class ContractUpdateDto
    {
        public string ContractId { get; set; }
        public string ContractCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusSign StatusSign { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdaterId { get; set; }
        public ActiveStatus Status { get; set; }

        //Relationship
        public string EmployeeId { get; set; }
        public string ContractTypeId { get; set; }
        public string? SalaryProfileId { get; set; }
    }
}
