using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(Datacontext context) : base(context)
        {

        }

        public IQueryable<Department> GetQueryable()
        {
            return _context.Set<Department>();
        }
        public async Task<List<Department>> GetAllWithFilterAsync()
        {
            try
            {
                BeginTransaction();
                List<Department> departments = new List<Department>();

                await CommitTransactionAsync();
                return departments;
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }


    }
}
