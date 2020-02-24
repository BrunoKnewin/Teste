using EZ.Knewin.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Infra.Data.Context
{
    public class TesteDbContext : DbContext
    {
        public TesteDbContext(DbContextOptions<TesteDbContext> options) : base(options)
        {
            
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            PrepararDataRegistro();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            PrepararDataRegistro();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void PrepararDataRegistro()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("DataDeCadastro").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property("DataDeCadastro").IsModified = false;
                        entry.Property("DateDeAtualizacao").CurrentValue = DateTime.Now;
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cidade>()
                        .HasOne(x => x.Estado);

        }
    }
}
