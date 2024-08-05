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
    public interface IContractService
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
            public ActiveStatus Status { get; set; }

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
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                return filter;
            }
        }

        [DataContract]
        public class ContractSearch
        {
            [DataMember(Order = 0)]
            public string ContractId { get; set; }

            [DataMember(Order = 1)]
            public string ContractCode { get; set; }

            [DataMember(Order = 2)]
            public DateTime StartDate { get; set; }

            [DataMember(Order = 3)]
            public DateTime? EndDate { get; set; }

            [DataMember(Order = 4)]
            public StatusSign StatusSign { get; set; }

            [DataMember(Order = 5)]
            public DateTime CreateDate { get; set; }

            [DataMember(Order = 6)]
            public string? CreatorId { get; set; }

            [DataMember(Order = 7)]
            public DateTime? UpdateDate { get; set; }

            [DataMember(Order = 8)]
            public string? UpdaterId { get; set; }

            [DataMember(Order = 9)]
            public ActiveStatus Status { get; set; }

            [DataMember(Order = 10)]
            public string EmployeeId { get; set; }

            [DataMember(Order = 11)]
            public string ContractTypeId { get; set; }

            [DataMember(Order = 12)]
            public string? SalaryProfileId { get; set; }

            [DataMember(Order = 13)]
            public Page Page { get; set; }

            public IQueryable<Contract> CreateFilter(IQueryable<Contract> filter)
            {
                if (ContractId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.ContractId == ContractId);
                }
                if (ContractCode.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.ContractCode == ContractCode);
                }
                if (StatusSign != StatusSign.All)
                {
                    filter = filter.Where(c => c.StatusSign == StatusSign);
                }
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                if (EmployeeId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.EmployeeId == EmployeeId);
                }
                if (ContractTypeId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.ContractTypeId == ContractTypeId);
                }
                if (SalaryProfileId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.SalaryProfileId == SalaryProfileId);
                }
                return filter;
            }
        }

        [DataContract]
        public class ListContractResult
        {
            [DataMember(Order = 1)]
            public List<ContractDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }
    }
}
