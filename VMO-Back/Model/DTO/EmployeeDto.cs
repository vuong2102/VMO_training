using System.ComponentModel.DataAnnotations;
using Model.Model;
using Model.Utils;

namespace Model.DTO
{
    public class EmployeeDto
    {
        public string EmployeeId { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên nhân viên")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ActiveStatus Status { get; set; }
        public TitleDetailDto Title { get; set; }
        public DepartmentDto Department { get; set; }

        public List<AllocatedAssets> AllocatedAssets;
    }

    public class EmployeeAddDto
    {
        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên nhân viên")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ActiveStatus Status { get; set; }
        public string TitleId { get; set; }
        public string DepartmentId { get; set; }
    }
}
