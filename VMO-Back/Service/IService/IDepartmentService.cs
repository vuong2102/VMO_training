using Core.Extensions;
using Model.DTO;
using Model.Model;
using Share.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IDepartmentService
    {

        [DataContract]
        public class DepartmentSearch
        {
            [DataMember(Order = 1)]
            public Page Page { get; set; }

            [DataMember(Order = 2)]
            public string Id { get; set; }

            [DataMember(Order = 3)]
            public string Name { get; set; }

            [DataMember(Order = 4)]
            public string DepartmentCode { get; set; }

            public IQueryable<Department> CreateFilter(IQueryable<Department> filter)
            {
                if (Id.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.DepartmentId == Id);
                }
                if (Name.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Name == Name);
                }
                if (DepartmentCode.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.DepartmentCode == DepartmentCode);
                }
                return filter;
            }
        }

        [DataContract]
        public class ListDepartmentResult
        {
            [DataMember(Order = 1)]
            public List<DepartmentDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }
    }
}
