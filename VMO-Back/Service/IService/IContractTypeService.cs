using Core.Extensions;
using Model.DTO;
using Model.Model;
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
            public string Id { get; set; }

            [DataMember(Order = 3)]
            public string Name { get; set; }

            [DataMember(Order = 4)]
            public string ContractCode { get; set; }

            [DataMember(Order = 5)]
            public int Term { get; set; }

            [DataMember(Order = 6)]
            public int Status { get; set; }

            public IQueryable<ContractType> CreateFilter(IQueryable<ContractType> filter)
            {
                if (Id.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.ContractTypeId == Id);
                }
                if (Name.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Name == Name);
                }
                if (ContractCode.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.ContractCode == ContractCode);
                }
                if (Term.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Term == Term);
                }
                if (Status.IsNotNullOrEmpty())
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
    }
}
