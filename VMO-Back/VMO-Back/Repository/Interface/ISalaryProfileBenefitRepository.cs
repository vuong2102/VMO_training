using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface ISalaryProfileBenefitRepository : IRepository<BenefitSalaryProfile>
    {
        IQueryable<BenefitSalaryProfile> GetQueryable();
    }
    
}
