using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface IContractTypeRepository : IRepository<ContractType>
    {
        IQueryable<ContractType> GetQueryable();
        Task<List<ContractTypeOverview>> GetOverViewEmployeeAsync();
    }
}
