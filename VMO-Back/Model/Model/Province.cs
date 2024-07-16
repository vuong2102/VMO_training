using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Province
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProvinceCode { get; set; }
        public int Status { get; set; }
    }
}
