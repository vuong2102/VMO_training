using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Utils
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ActiveStatus
    {
        [Display(Name = "Tất cả")]
        All = -1,
        [Display(Name = "Hoạt động")]
        NoActive = 0,
        [Display(Name = "Không hoạt động")]
        Active = 1

    }
}
