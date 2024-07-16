using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class AllowanceRepository : Repository<Allowance>, IAllowanceRepository
    {
        public AllowanceRepository(Datacontext context) : base(context)
        {

        }
        public IQueryable<Allowance> GetQueryable()
        {
            return _context.Set<Allowance>();
        }
    
    }
}
