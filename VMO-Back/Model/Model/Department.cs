using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Department
    {
        [Key]
        public string DepartmentId { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên phòng ban")]
        public string Name { get; set; }
        public string DepartmentCode { get; set; }
        public int DepartmentType { get; set; }
        public string ParentId { get; set; }
        public int Status { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Title> Titles { get; set; }
    }
}
