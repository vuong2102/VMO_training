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
    public interface IContractTypeService
    {
        [DataContract]
        public class ContractTypeSearch
        {
            [DataMember(Order = 1)]
            public Page Page { get; set; }

            [DataMember(Order = 2)]
            public string ContractTypeId { get; set; }

            [DataMember(Order = 3)]
            public string Name { get; set; }

            [DataMember(Order = 4)]
            public string ContractCode { get; set; }

            [DataMember(Order = 5)]
            public int Term { get; set; }

            [DataMember(Order = 6)]
            public ActiveStatus Status { get; set; }

            public IQueryable<ContractType> CreateFilter(IQueryable<ContractType> filter)
            {
                if (ContractTypeId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.ContractTypeId == ContractTypeId);
                }
                if (Name.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Name == Name);
                }
                if (ContractCode.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.ContractCode == ContractCode);
                }
                if (Term == -1)
                {
                    filter = filter.Where(c => c.Term == Term);
                }
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                return filter;
            }
        }

        [DataContract]
        public class ListContractTypeResult
        {
            [DataMember(Order = 1)]
            public List<ContractTypeDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }

        [DataContract]
        public class ListContractTypeOverviewResult
        {
            [DataMember(Order = 1)]
            public List<ContractTypeOverview> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }

        [DataContract]
        public class OverviewIncDec
        {
            [DataMember(Order = 1)]
            public int Active { get; set; }

            [DataMember(Order = 2)]
            public int NoActive { get; set; }

        }
    }
}
