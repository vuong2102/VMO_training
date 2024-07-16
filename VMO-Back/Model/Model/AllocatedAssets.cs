using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class AllocatedAssets
    {
        [Key]
        public string AllocatedAssetId { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên tài sản")]
        public string Name { get; set; }
        public string Code { get; set; }
        public int Number { get; set; }
        public DateTime DateAllocated { get; set; }
        public int StatusAsset { get; set; }
        public int Status {  get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
    }
}
