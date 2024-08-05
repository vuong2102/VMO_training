using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(Datacontext context) : base(context)
        {

        }
        public IQueryable<Contract> GetQueryable()
        {
            return _context.Set<Contract>();
        }
        public async Task<List<Contract>> GetAllWithFilterAsync()
        {
            try
            {
                BeginTransaction();
                List<Contract> employees = new List<Contract>();
                employees.Add(new Contract());
                await CommitTransactionAsync();
                return employees;
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<string> GetContractCodeMax()
        {
            try
            {
                BeginTransaction();
                var highestTitleCode = Query
                    .Where(t => t.ContractCode.StartsWith("HD"))
                    .OrderByDescending(t => t.ContractCode)
                    .Select(t => t.ContractCode)
                    .FirstOrDefaultAsync();

                if (highestTitleCode.Result == null)
                {
                    return "HD0001";
                }
                await CommitTransactionAsync();
                return highestTitleCode.Result.ToString();
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }
    }
}
