using Core.Extensions;
using Model.DTO;
using Model.Model;
using Model.Utils;
using Share.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.IService
{
    public interface ISalaryProfileAllowanceService
    {
        [DataContract]
        public class SalaryProfileAllowanceSearch
        {
            [DataMember(Order = 1)]
            public Page Page { get; set; }

            [DataMember(Order = 2)]
            public string? AllowanceSalaryProfileId { get; set; }

            [DataMember(Order = 3)]
            public string? AllowanceId { get; set; }

            [DataMember(Order = 4)]
            public string? SalaryProfileId { get; set; }

            [DataMember(Order = 5)]
            public DateTime? CreateDate { get; set; }

            [DataMember(Order = 6)]
            public ActiveStatus Status { get; set; }

            public IQueryable<AllowanceSalaryProfile> CreateFilter(IQueryable<AllowanceSalaryProfile> filter)
            {
                if (AllowanceSalaryProfileId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.AllowanceSalaryProfileId == AllowanceSalaryProfileId);
                }
                if (AllowanceId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.AllowanceId == AllowanceId);
                }
                if (SalaryProfileId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.SalaryProfileId == SalaryProfileId);
                }
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                return filter;
            }
        }
        [DataContract]
        public class ListAllowanceSalaryProfileResult
        {
            [DataMember(Order = 1)]
            public List<AllowanceSalaryProfileDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }
    }

}
