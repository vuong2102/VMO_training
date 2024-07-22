using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class SalaryProfileAllowanceRepositosy : Repository<AllowanceSalaryProfile>, ISalaryProfileAllowanceRepository
    {
        public SalaryProfileAllowanceRepositosy(Datacontext context) : base(context)
        {

        }
        public IQueryable<AllowanceSalaryProfile> GetQueryable()
        {
            return _context.Set<AllowanceSalaryProfile>();
        }
    }
}
