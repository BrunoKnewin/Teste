using Knewin.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knewin.Core.Repositories
{
    public class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        private readonly TContext _context;

        protected readonly DbSet<TEntity> DbSet;

        public EfCoreRepository(TContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        private void SaveChanges()
            => _context.SaveChanges();

        public virtual Task<TEntity> GetByIdAsync(long id)
            => DbSet.FindAsync(id);

        public virtual TEntity Get(long id)
            => DbSet.Find(id);

        public virtual List<TEntity> GetPage(int limit, int offset)
            => DbSet.Take(limit).Skip(offset).ToList();

        public List<TEntity> GetAllById(long[] ids)
            => DbSet.Where(e => ids.Contains(e.Id)).ToList();

        public bool Exists(long id)
            => DbSet.Any(e => e.Id == id);

        public virtual IQueryable<TEntity> GetAll()
            => DbSet;

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            SaveChanges();
        }

        public async void AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
            SaveChanges();
        }

        public void Remove(long id)
        {
            var entity = DbSet.Find(id);

            if (entity != null)
            {
                DbSet.Remove(entity);
                SaveChanges();
            }
        }

        public bool Add(IEnumerable<TEntity> items)
        {
            var list = items.ToList();

            foreach (var item in list)
                DbSet.Add(item);

            SaveChanges();
            return true;
        }

        public bool Update(IEnumerable<TEntity> entities)
        {
            var list = entities.ToList();

            foreach (var item in list)
                DbSet.Update(item);

            _context.SaveChanges();
            return true;
        }
    }
}
