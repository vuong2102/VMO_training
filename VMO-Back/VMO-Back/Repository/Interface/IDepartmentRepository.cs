using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IQueryable<Department> GetQueryable();
        Task<List<Department>> GetAllWithFilterAsync();

    }
}
