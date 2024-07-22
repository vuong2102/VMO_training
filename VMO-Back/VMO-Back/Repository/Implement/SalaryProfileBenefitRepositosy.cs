using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class SalaryProfileBenefitRepositosy : Repository<BenefitSalaryProfile>, ISalaryProfileBenefitRepository
    {
        public SalaryProfileBenefitRepositosy(Datacontext context) : base(context)
        {

        }
        public IQueryable<BenefitSalaryProfile> GetQueryable()
        {
            return _context.Set<BenefitSalaryProfile>();
        }

   
    }
}
