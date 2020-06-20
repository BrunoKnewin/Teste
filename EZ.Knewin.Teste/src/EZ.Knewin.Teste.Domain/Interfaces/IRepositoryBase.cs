using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        TEntity Atualizar(TEntity entity);
        void Deletar(TEntity entity);
        ICollection<TEntity> ObterTodos();
        Task<ICollection<TEntity>> ObterTodosAsync();
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
