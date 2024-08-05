using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Model.Model;
using VMO_Back.Repository.Interface;
using static Service.IService.IEmployeeService;

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

        public async Task<List<ContractTypeOverview>> GetOverViewEmployeeAsync()
        {
            try
            {
                BeginTransaction();
                var result = (from ContractType ct in _context.Set<ContractType>()
                            join Contract c in _context.Set<Contract>() 
                            on ct.ContractTypeId equals c.ContractTypeId into ctGroup
                            from c in ctGroup.DefaultIfEmpty()
                            group c by new { ct.ContractTypeId, ct.Name } into g
                            select new ContractTypeOverview
                            {
                                ContractTypeId = g.Key.ContractTypeId,
                                ContractTypeName = g.Key.Name,
                                Number = g.Count(c => c != null)
                            }).ToList();
                await CommitTransactionAsync();
                return result;
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }
    }
}
