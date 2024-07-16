using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class ContractTypeRepository : Repository<ContractType>, IContractTypeRepository
    {
        public ContractTypeRepository(Datacontext context) : base(context)
        {

        }

        public IQueryable<ContractType> GetQueryable()
        {
            return _context.Set<ContractType>();
        }
    
    }
}
