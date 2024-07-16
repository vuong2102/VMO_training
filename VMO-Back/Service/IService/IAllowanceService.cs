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
    public interface IAllowanceService
    {
        [DataContract]
        public class AllowanceSearch
        {
            [DataMember(Order = 1)]
            public Page Page { get; set; }

            [DataMember(Order = 2)]
            public string AllowanceId { get; set; }

            [DataMember(Order = 3)]
            public string Name { get; set; }

            [DataMember(Order = 4)]
            public int Amount { get; set; }

            [DataMember(Order = 5)]
            public virtual ActiveStatus Status { get; set; }

            public IQueryable<Allowance> CreateFilter(IQueryable<Allowance> filter)
            {
                if (AllowanceId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.AllowanceId == AllowanceId);
                }
                if (Name.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Name == Name);
                }
                if (Amount != 0)
                {
                    filter = filter.Where(c => c.Amount == Amount);
                }
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                return filter;
            }
        }
        [DataContract]
        public class ListAllowanceResult
        {
            [DataMember(Order = 1)]
            public List<AllowanceDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }
        }
    }
}
