using Model.Utils;
using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Title
    {
        [Key]
        public string TitleId { get; set; }
        public string Name { get; set; }
        public string TitleCode { get; set; }
        public ActiveStatus Status { get; set; }

        //Relationship
        public string DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Employee> Employees { get; set; }


    }
}
