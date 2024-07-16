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
    public interface IBenefitService
    {
        [DataContract]
        public class BenefitSearch
        {
            [DataMember(Order = 1)]
            public Page Page { get; set; }

            [DataMember(Order = 2)]
            public virtual string BenefitId { get; set; }

            [DataMember(Order = 3)]
            public virtual string Type { get; set; }

            [DataMember(Order = 4)]
            public virtual int Expense { get; set; }

            [DataMember(Order = 5)]
            public virtual ActiveStatus Status { get; set; }

            public IQueryable<Benefit> CreateFilter(IQueryable<Benefit> filter)
            {
                if (BenefitId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.BenefitId == BenefitId);
                }
                if (Type.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Type == Type);
                }
                if (Expense != 0)
                {
                    filter = filter.Where(c => c.Expense == Expense);
                }
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                return filter;
            }
        }

        [DataContract]
        public class ListBenefitResult
        {
            [DataMember(Order = 1)]
            public List<BenefitDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }
    }
}
