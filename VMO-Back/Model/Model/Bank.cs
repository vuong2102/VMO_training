using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Bank
    {
        [Key]
        public string Id { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên ngân hàng")]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
