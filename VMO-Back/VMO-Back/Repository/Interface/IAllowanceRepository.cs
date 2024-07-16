using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface IAllowanceRepository : IRepository<Allowance>
    {
        IQueryable<Allowance> GetQueryable();
    }
}
