using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AllowanceDto
    {
        public string AllowanceId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public ActiveStatus Status { get; set; }
    }

    public class AllowanceAddDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public ActiveStatus Status { get; set; }
    }

    public class AllowanceUpdateDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public ActiveStatus Status { get; set; }
    }
}
