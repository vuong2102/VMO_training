using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

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

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusSign
    {
        [Display(Name = "Tất cả")]
        All = -1,
        [Display(Name = "Chưa ký")]
        NoSign = 0,
        [Display(Name = "Đã ký")]
        Signed = 1,
        [Display(Name = "Chờ ký")]
        WaitingSign = 2
    }
}
