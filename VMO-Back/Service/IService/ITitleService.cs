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
    public interface ITitleService
    {
        [DataContract]
        public class TitleSearch
        {
            [DataMember(Order = 1)]
            public Page Page { get; set; }

            [DataMember(Order = 2)]
            public string TitleId { get; set; }

            [DataMember(Order = 3)]
            public string Name { get; set; }

            [DataMember(Order = 4)]
            public string TitleCode { get; set; }

            [DataMember(Order = 5)]
            public ActiveStatus Status { get; set; }
            
            [DataMember(Order = 6)]
            public string DepartmentId { get; set; }

            public IQueryable<Title> CreateFilter(IQueryable<Title> filter)
            {
                if (TitleId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.TitleId == TitleId);
                }
                if (Name.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Name == Name);
                }
                if (TitleCode.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.TitleCode == TitleCode);
                }
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                if (DepartmentId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.DepartmentId == DepartmentId);
                }
                return filter;
            }
        }

        [DataContract]
        public class ListTitleResult
        {
            [DataMember(Order = 1)]
            public List<TitleDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }

        [DataContract]
        public class ListTitleDetailResult
        {
            [DataMember(Order = 1)]
            public List<TitleDetailDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }
    }
}
