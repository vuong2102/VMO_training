using Core.Extensions;
using Model.DTO;
using Model.Model;
using Model.Utils;
using Share.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IEmployeeService
    {
        [DataContract]
        public class EmployeeSearch
        {
            [DataMember(Order = 1)]
            public Page Page { get; set; }

            [DataMember(Order = 2)]
            public virtual string EmployeeId { get; set; }

            [DataMember(Order = 3)]
            public virtual string Name { get; set; }

            [DataMember(Order = 4)]
            public virtual string Code { get; set; }

            [DataMember(Order = 5)]
            public virtual string Sex { get; set; }

            [DataMember(Order = 6)]
            public virtual DateTime? DateOfBirth { get; set; }

            [DataMember(Order = 7)]
            public virtual string Email { get; set; }

            [DataMember(Order = 8)]
            public virtual string PhoneNumber { get; set; }

            [DataMember(Order = 9)]
            public virtual ActiveStatus Status { get; set; }

            [DataMember(Order = 10)]
            public virtual string TitleId { get; set; }

            [DataMember(Order = 11)]
            public virtual string DepartmentId { get; set; }

            public IQueryable<Employee> CreateFilter(IQueryable<Employee> filter)
            {
                if (EmployeeId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.EmployeeId == EmployeeId);
                }
                if (Name.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Name == Name);
                }
                if (Code.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Code == Code);
                }
                if (Sex.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Sex == Sex);
                }
                if (DateOfBirth.HasValue)
                {
                    filter = filter.Where(c => c.DateOfBirth == DateOfBirth);
                }
                if (Email.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.Email == Email);
                }
                if (PhoneNumber.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.PhoneNumber == PhoneNumber);
                }
                if (Status != ActiveStatus.All)
                {
                    filter = filter.Where(c => c.Status == Status);
                }
                if (DepartmentId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.DepartmentId == DepartmentId);
                }
                if (TitleId.IsNotNullOrEmpty())
                {
                    filter = filter.Where(c => c.TitleId == TitleId);
                }
                return filter;
            }
        }
        [DataContract]
        public class ListEmployeeResult
        {
            [DataMember(Order = 1)]
            public List<EmployeeDto> Data { get; set; }

            [DataMember(Order = 2)]
            public int Total { get; set; }

        }
    }
}
