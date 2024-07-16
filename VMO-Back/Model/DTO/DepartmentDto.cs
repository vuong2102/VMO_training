using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class DepartmentDto
    {
        public string DepartmentId { get; set; } = null;

        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string DepartmentCode { get; set; }
    }

    public class DepartmentAddDto
    {
        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public int DepartmentType { get; set; }
        public string? ParentId { get; set; } = null!;
    }

    public class DepartmentUpdateDto
    {
        [Required(ErrorMessage = "You must enter {0}")]
        public string DepartmentId { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string DepartmentCode { get; set; }
    }
}
