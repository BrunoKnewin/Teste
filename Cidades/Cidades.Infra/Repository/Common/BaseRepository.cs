using Cidades.Domain.Repositories.Common;
using Cidades.Shared.Infra;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ServiceStack;

namespace Cidades.Infra.Repository.Common
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<T> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;
        }

        public virtual void Add(T obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task<T> GetById(string id)
        {
            ConfigDbSet();
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            ConfigDbSet();
            var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(T obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.GetId()), obj));
        }

        public virtual void Remove(string id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            ConfigDbSet();
            var all = DbSet.AsQueryable<T>().Where(predicate);
            return all;
        }
    }
}
