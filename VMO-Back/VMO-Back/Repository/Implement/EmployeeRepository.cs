using Core.Pattern.Repository;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Datacontext _context) : base(_context) { }

        public IQueryable<Employee> GetQueryable()
        {
            return _context.Set<Employee>();
        }
        public async Task<List<Employee>> GetAllWithFilterAsync()
        {
            try
            {
                BeginTransaction();
                List<Employee> employees = new List<Employee>();
                employees.Add(new Employee());
                await CommitTransactionAsync();
                return employees;
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }
    }
}
