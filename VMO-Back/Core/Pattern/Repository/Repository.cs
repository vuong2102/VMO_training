using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pattern.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected IDbContextTransaction _transaction;

        public Repository(DbContext context)
        {
            this._context = context;
        }
        public IQueryable<T> Query { get => _context.Set<T>(); }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<bool> AddEntityAsync(T entity, bool usingTransaction = true)
        {
            if (usingTransaction) BeginTransaction();
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            if (usingTransaction) await CommitTransactionAsync();
            return true;
        }

        public async Task<bool> AddEntityAsync(IEnumerable<T> collection, bool usingTransaction = true)
        {
            if (usingTransaction) BeginTransaction();
            await _context.Set<T>().AddRangeAsync(collection);
            await _context.SaveChangesAsync();
            if (usingTransaction) await CommitTransactionAsync();
            return true;
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<bool> UpdateEntityAsync(T entity, bool usingTransaction = true)
        {
            if (usingTransaction) BeginTransaction();
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            if (usingTransaction) await CommitTransactionAsync();
            return true;
        }

        public async Task<bool> UpdateEntityAsync(IEnumerable<T> collection, bool usingTransaction = true)
        {
            if (usingTransaction) BeginTransaction();
            _context.Set<T>().UpdateRange(collection);
            await _context.SaveChangesAsync();
            if (usingTransaction) await CommitTransactionAsync();
            return true;
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> DeleteEntityAsync(T entity, bool usingTransaction = true)
        {
            if (usingTransaction) BeginTransaction();
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            if (usingTransaction) await CommitTransactionAsync();
            return true;
        }

        public async Task<bool> DeleteEntityAsync(IEnumerable<T> collection, bool usingTransaction = true)
        {
            if (usingTransaction) BeginTransaction();
            _context.Set<T>().RemoveRange(collection);
            await _context.SaveChangesAsync();
            if (usingTransaction) await CommitTransactionAsync();
            return true;
        }

        public void Delete(object key)
        {
            var entity = _context.Set<T>().Find(key);
            if (entity != null) _context.Set<T>().Remove(entity);
        }

        public async Task<bool> DeleteAsync(object key, bool usingTransaction = true)
        {
            var entity = await _context.Set<T>().FindAsync(key);
            if (entity == null) return false;
            if (usingTransaction) BeginTransaction();
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            if (usingTransaction) await CommitTransactionAsync();
            return true;
        }

        public async Task<bool> DeleteWithListKeyAsync(IEnumerable<object> collection, bool usingTransaction = true)
        {
            foreach (var key in collection)
            {
                await DeleteAsync(key, usingTransaction);
            }
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllBySearchAsync(Expression<Func<T, bool>> search)
        {
            return await _context.Set<T>().Where(search).ToListAsync();
        }

        public IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToList();
        }

        public void BeginTransaction()
        {
            if (_transaction == null) _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }

        public async Task<bool> CommitTransactionAsync()
        {

            try
            {
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void SetFetchPage(int from, int maxResult)
        {
            // This method can be implemented based on the specific requirements
        }

        public void ResetFetchPage()
        {
            // This method can be implemented based on the specific requirements
        }

        public IList<T> GetAll(int pageIndex, int pageSize, out int total)
        {
            total = _context.Set<T>().Count();
            return _context.Set<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public IQueryable<T> GetPage<TSelect>(Expression<Func<T, bool>> search, int pageIndex, int pageSize, Expression<Func<T, TSelect>> orderBy, OrderType orderType)
        {
            var query = _context.Set<T>().Where(search);
            return orderType == OrderType.Asc
                ? query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                : query.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public (IList<T>, int) GetPageWithTotal<TSelect>(Expression<Func<T, bool>> search, int pageIndex, int pageSize, Expression<Func<T, TSelect>> orderBy, OrderType orderType)
        {
            var query = _context.Set<T>().Where(search);
            var total = query.Count();
            var result = orderType == OrderType.Asc
                ? query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
                : query.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return (result, total);
        }

        public async Task<IList<T>> GetPageWithTransactionAsync<TSelect>(Expression<Func<T, bool>> search, int pageIndex, int pageSize, Expression<Func<T, TSelect>> orderBy, OrderType orderType)
        {
            var query = GetPage(search, pageIndex, pageSize, orderBy, orderType);
            return await query.ToListAsync();
        }

        public async Task<(IList<T>, int)> GetPageWithTransactionWithTotalAsync<TSelect>(Expression<Func<T, bool>> search, int pageIndex, int pageSize, Expression<Func<T, TSelect>> orderBy, OrderType orderType)
        {
            var result = GetPageWithTotal(search, pageIndex, pageSize, orderBy, orderType);
            return (await Task.FromResult(result.Item1), result.Item2);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> GetWithTransactionAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetAsync(predicate);
        }

        public async Task<IList<T>> ExecuteWithTransactionAsync(IQueryable<T> query, bool usingTransaction = true)
        {
            try
            {
                if (usingTransaction) BeginTransaction();
                var result = await query.ToListAsync();
                if (usingTransaction) await CommitTransactionAsync();
                return result;
            }
            catch (Exception)
            {
                if (usingTransaction) await RollbackTransactionAsync();
                throw;
            }
        }

        public T GetByKey(object key)
        {
            return _context.Set<T>().Find(key);
        }

        public void Clear()
        {
            // Not directly applicable in EF Core. Could be implemented based on specific requirements
        }

        public void ClearSession()
        {
            // Not directly applicable in EF Core. Could be implemented based on specific requirements
        }

        public void SetBatchSize(int size)
        {
            // Not directly applicable in EF Core. Could be implemented based on specific requirements
        }

        public async Task<(IList<T>, int)> GetPageWithTotalAsync<TSelect>(IQueryable<T> query, int pageIndex, int pageSize, Expression<Func<T, TSelect>> orderBy, OrderType orderType)
        {
            var total = await query.CountAsync();
            var result = orderType == OrderType.Asc
                ? await query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync()
                : await query.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return (result, total);
        }

        public async Task<(IList<T>, int)> GetPageWithTotalAsync(IQueryable<T> query, int pageIndex, int pageSize)
        {
            var total = await query.CountAsync();
            var result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return (result, total);
        }
    }
    public enum OrderType
    {
        Asc,
        Desc
    }
}
