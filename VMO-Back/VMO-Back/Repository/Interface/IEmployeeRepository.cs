using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IQueryable<Employee> GetQueryable();
        Task<List<Employee>> GetAllWithFilterAsync();

    }
}
