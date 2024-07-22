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

namespace Service.IService
{
    public interface ISalaryProfileBenefitService
    {
        [DataContract]
        public class SalaryProfileBenefitSearch
        {
            [DataMember(Order = 1)]
            public Page Page { get; set; }

            [DataMember(Order = 2)]
            public string BenefitSalaryProfileId { get; set; }

            [DataMember(Order = 3)]
            public string BenefitId { get; set; }

            [DataMember(Order = 4)]
            public string SalaryProfileId { get; set; }

            [DataMember(Order = 5)]
            public DateTime CreateDate { get; set; }

            [DataMember(Order = 6)]
            public ActiveStatus Status { get; set; }

            public IQueryable<BenefitSalaryProfile> CreateFilter(IQueryable<BenefitSalaryProfile> filter)
            {
                if (BenefitSalaryProfileId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.BenefitSalaryProfileId == BenefitSalaryProfileId);
                }
                if (BenefitId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.BenefitId == BenefitId);
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
        public class ListSalaryProfileBenefitResult
        {
            [DataMember(Order = 1)]
            public List<SalaryProfileDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }
    }
}
