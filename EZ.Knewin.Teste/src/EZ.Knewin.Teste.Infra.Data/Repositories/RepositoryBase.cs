using EZ.Knewin.Teste.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Context;

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }

        public TEntity Adicionar(TEntity entity)
        {
            return Context.Add(entity).Entity;
        }

        public TEntity Atualizar(TEntity entity)
        {
            try
            {
                return Context.Update(entity).Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<TEntity> ObterTodos()
        {
            var query = Context.Set<TEntity>();
            return query.Any() ? query.ToList() : new List<TEntity>();
        }

        public async Task<ICollection<TEntity>> ObterTodosAsync()
        {
            var query = Context.Set<TEntity>();
            return query.Any() ? await query.ToListAsync() : new List<TEntity>();
        }

        public void Deletar(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public bool SaveChanges()
        {
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
