using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface ISalaryProfileRepository : IRepository<SalaryProfile>
    {
        IQueryable<SalaryProfile> GetQueryable();

        Task<List<SalaryProfile>> GetAllWithFilterAsync();

    }
}
