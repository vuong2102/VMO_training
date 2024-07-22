using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using static Service.IService.IEmployeeService;

namespace VMO_Back.Repository.Interface
{
    public interface ISalaryProfileRepository : IRepository<SalaryProfile>
    {
        IQueryable<SalaryProfile> GetQueryable();

        Task<List<SalaryProfile>> GetAllWithFilterAsync(EmployeeSearch model);

    }
}
