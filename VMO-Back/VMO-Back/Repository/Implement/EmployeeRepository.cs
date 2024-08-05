using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using Model.Model;
using System.Linq;
using VMO_Back.Repository.Interface;
using static Service.IService.IEmployeeService;

namespace VMO_Back.Repository.Implement
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Datacontext _context) : base(_context) { }

        public IQueryable<Employee> GetQueryable()
        {
            return _context.Set<Employee>();
        }
        public async Task<List<Employee>> GetAllWithFilterAsync(EmployeeSearch model)
        {
            try
            {
                BeginTransaction();
                var employeeDatas = (from Employee emp in _context.Set<Employee>()
                                    join SalaryProfile sa in _context.Set<SalaryProfile>()
                                    on emp.EmployeeId equals sa.EmployeeId  into es
                                    from sa in es.DefaultIfEmpty()
                                    where sa == null || emp.EmployeeId != sa.EmployeeId
                                    select emp).ToList();
                await CommitTransactionAsync();
                return employeeDatas;
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<List<Employee>> GetAllWithEmployeeCode(EmployeeSearch model)
        {
            var employees = Query.Where(c => c.Code == model.Code).ToList();
            return employees;
        }
    }
}
