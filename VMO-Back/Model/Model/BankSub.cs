using System.ComponentModel.DataAnnotations;
namespace Model.Model
{
    public class BankSub
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string BankId { get; set; }
    }
}
