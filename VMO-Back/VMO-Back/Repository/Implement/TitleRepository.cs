using Core.Pattern.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Repository.Implement
{
    public class TitleRepository : Repository<Title>, ITitleRepository
    {
        public TitleRepository(Datacontext context) : base(context)
        {

        }
        public IQueryable<Title> GetQueryable()
        {
            return _context.Set<Title>();
        }

        public async Task<string> GetTitleCodeMax()
        {
            try
            {
                BeginTransaction();
                var highestTitleCode = Query
                    .Where(t => t.TitleCode.StartsWith("CD"))
                    .OrderByDescending(t => t.TitleCode)
                    .Select(t => t.TitleCode)
                    .FirstOrDefaultAsync();

                if (highestTitleCode.Result == null)
                {
                    return "CD0001";
                }
                await CommitTransactionAsync();
                return highestTitleCode.Result.ToString();
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }
    }
}
