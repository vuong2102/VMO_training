using Core.Pattern.Repository;
using Model.Model;
using Service.IService;
using VMO_Back.Repository.Interface;
using static Service.IService.IEmployeeService;

namespace VMO_Back.Repository.Implement
{
    public class SalaryProfileRepository : Repository<SalaryProfile>, ISalaryProfileRepository
    {
        public SalaryProfileRepository(Datacontext _context) : base(_context) { }
        public IQueryable<SalaryProfile> GetQueryable()
        {
            return _context.Set<SalaryProfile>();
        }
        public async Task<List<SalaryProfile>> GetAllWithFilterAsync(EmployeeSearch model)
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
