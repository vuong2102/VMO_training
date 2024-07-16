using Model.Model;
using Model.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class TitleDto
    {
        public string TitleId { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên chức danh")]
        public string Name { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập mã chức danh")]
        public string TitleCode { get; set; }
        public ActiveStatus Status { get; set; }

        public string DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }

    }

    public class TitleDetailDto
    {
        public string TitleId { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên chức danh")]
        public string Name { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập mã chức danh")]
        public string TitleCode { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập mã phòng ban")]
        public ActiveStatus Status { get; set; }

    }

    public class TitleAddDto
    {
        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }

        [Required, MinLength(4, ErrorMessage = "You must enter {0}")]
        public string TitleCode { get; set; }

        [Required, MinLength(4, ErrorMessage = "You must enter {0}")]
        public string DepartmentId { get; set; }

        [Required]
        public ActiveStatus Status { get; set; }
    }

    public class TitleUpdateDto
    {
        [Required(ErrorMessage = "You must enter {0}")]
        public string TitleId { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }

        [Required, MinLength(4, ErrorMessage = "You must enter {0}")]
        public string TitleCode { get; set; }
        public ActiveStatus Status { get; set; }

        [Required, MinLength(4, ErrorMessage = "You must enter {0}")]
        public string DepartmentId { get; set; }

    }

    public class TitleCodeMax
    {
        public string TitleCode { get; set; }
    }
}
