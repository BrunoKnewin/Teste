using Knewin.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Knewin.Core.Services
{

    public interface ICrudService<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(long id);

        void Insert(TEntity entity);

        bool Insert(IEnumerable<TEntity> items);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> Update(IEnumerable<TEntity> entities);

        void Delete(long id);

        List<TEntity> GetPage(int limit, int offset);

        TEntity Get(long id);

        List<TEntity> GetAllById(long[] ids);

        bool Exists(long id);

        bool CanDelete(long id);
    }
}
