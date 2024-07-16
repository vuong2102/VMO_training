using Model.Utils;
using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên nhân viên")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ActiveStatus Status { get; set; }


        //Relationship
        public string? TitleId { get; set; }
        public Title? Title { get; set; }
        public string? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public Contract? Contract { get; set; }
        public SalaryProfile? SalaryProfile { get; set; }
        public virtual List<AllocatedAssets>? AllocatedAssets { get; set; }

    }
}
