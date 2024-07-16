using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface IBenefitRepository : IRepository<Benefit>
    {
        IQueryable<Benefit> GetQueryable();
    
    }
}
