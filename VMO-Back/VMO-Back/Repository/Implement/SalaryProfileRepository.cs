using Core.Pattern.Repository;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class SalaryProfileRepository : Repository<SalaryProfile>, ISalaryProfileRepository
    {
        public SalaryProfileRepository(Datacontext _context) : base(_context) { }
        public IQueryable<SalaryProfile> GetQueryable()
        {
            return _context.Set<SalaryProfile>();
        }
        public async Task<List<SalaryProfile>> GetAllWithFilterAsync()
        {
            try
            {
                BeginTransaction();
                List<SalaryProfile> salaryProfiles = new List<SalaryProfile>();
                salaryProfiles.Add(new SalaryProfile());
                await CommitTransactionAsync();
                return salaryProfiles;
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }
    }
}
