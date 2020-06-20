using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Domain.Interfaces;
using EZ.Knewin.Teste.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Infra.Data.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        private readonly TesteDbContext _context;

        public CidadeRepository(TesteDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<ICollection<Cidade>> ObterCidadesProximas(int cidadeId)
        {
            return await _context.Set<Cidade>()
                .Where(c => c.Id == cidadeId)
                .ToListAsync();
        }

        public async Task<ICollection<Cidade>> ObterListaPorIds(int[] ids)
        {
            return await _context.Set<Cidade>()
                .Where(c => ids.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<Cidade> ObterPorId(int id) 
            => await _context.Set<Cidade>().FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Cidade> ObterPorNome(string nome) 
            => await _context.Set<Cidade>().FirstOrDefaultAsync(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        public async Task<int> ObterTotalDeHabitantesPorCidades(int[] ids)
        {
            return await _context.Set<Cidade>()
                .Where(c => ids.Contains(c.Id))
                .SumAsync(c => c.QuantidadeDeHabitantes);
        }
    }
}
