using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class BenefitRepository : Repository<Benefit>, IBenefitRepository
    {
        public BenefitRepository(Datacontext context) : base(context)
        {

        }
        public IQueryable<Benefit> GetQueryable()
        {
            return _context.Set<Benefit>();
        }
    

    }
}
