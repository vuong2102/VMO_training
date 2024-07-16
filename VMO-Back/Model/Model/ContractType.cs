using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class ContractType
    {
        [Key]
        public string ContractTypeId { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên hợp đồng")]
        public string Name { get; set; }
        public string ContractCode { get; set; }
        public int Term { get; set; }
        public int Status { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        
    }
}
