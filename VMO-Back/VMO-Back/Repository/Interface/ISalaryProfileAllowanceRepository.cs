using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface ISalaryProfileAllowanceRepository : IRepository<AllowanceSalaryProfile>
    {
        IQueryable<AllowanceSalaryProfile> GetQueryable();
    }
}
