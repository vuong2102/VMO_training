using Core.Pattern.Repository;
using Model.Model;

namespace VMO_Back.Repository.Interface
{
    public interface ITitleRepository : IRepository<Title>
    {
        IQueryable<Title> GetQueryable();
        Task<string> GetTitleCodeMax();
    }
}
