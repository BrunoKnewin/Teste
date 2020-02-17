using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cidades.Domain.Repositories.Common
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter);
        void Update(TEntity obj);
        void Remove(string id);
    }
}
