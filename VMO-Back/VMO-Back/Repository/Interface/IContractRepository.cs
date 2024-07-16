using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface IContractRepository : IRepository<Contract>
    {
        IQueryable<Contract> GetQueryable();
        Task<List<Contract>> GetAllWithFilterAsync();
    }
}
