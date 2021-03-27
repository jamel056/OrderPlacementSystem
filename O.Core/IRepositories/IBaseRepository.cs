using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace O.Core.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveAsync();
    }
}
