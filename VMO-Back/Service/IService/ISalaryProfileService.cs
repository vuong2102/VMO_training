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
    public interface ISalaryProfileService
    {
        [DataContract]
        public class SalaryProfileSearch
        {
            [DataMember(Order = 1)]
            public string SalaryProfileId { get; set; }

            [DataMember(Order = 2)]
            public int BasicSalary { get; set; }

            [DataMember(Order = 3)]
            public int Bonus { get; set; }

            [DataMember(Order = 4)]
            public int Deduction { get; set; }

            [DataMember(Order = 5)]
            public int NetSalary { get; set; }

            [DataMember(Order = 6)]
            public string SalaryRank { get; set; }

            [DataMember(Order = 7)]
            public string SalaryLevel { get; set; }

            [DataMember(Order = 8)]
            public DateTime CreateDate { get; set; }

            [DataMember(Order = 9)]
            public string CreatorId { get; set; }

            [DataMember(Order = 10)]
            public DateTime UpdateDate { get; set; }

            [DataMember(Order = 11)]
            public string UpdaterId { get; set; }

            [DataMember(Order = 12)]
            public ActiveStatus Status { get; set; }
            
            [DataMember(Order = 13)]
            public Page Page { get; set; }

            [DataMember(Order = 14)]
            public string SalaryProfileCode { get; set; }
            public IQueryable<SalaryProfile> CreateFilter(IQueryable<SalaryProfile> filter)
            {
                if (SalaryProfileId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.SalaryProfileId == SalaryProfileId);
                }
                if (SalaryProfileCode.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.SalaryProfileCode == SalaryProfileCode);
                }
                if (BasicSalary.IsGreaterThan0())
                {
                    filter = filter.Where(c => c.BasicSalary == BasicSalary);
                }
                if (Bonus.IsGreaterThan0())
                {
                    filter = filter.Where(c => c.Bonus == Bonus);
                }
                if (Deduction.IsGreaterThan0())
                {
                    filter = filter.Where(c => c.Deduction == Deduction);
                }
                if (NetSalary.IsGreaterThan0())
                {
                    filter = filter.Where(c => c.NetSalary == NetSalary);
                }
                if (NetSalary.IsGreaterThan0())
                {
                    filter = filter.Where(c => c.NetSalary == NetSalary);
                }
                if (SalaryRank.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.SalaryRank == SalaryRank);
                }
                if (SalaryLevel.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.SalaryLevel == SalaryLevel);
                }    
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                return filter;
            }
        }
        [DataContract]
        public class ListSalaryProfileResult
        {
            [DataMember(Order = 1)]
            public List<SalaryProfileDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }
    }
}
