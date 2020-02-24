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
        public DbSet<User> Users { get; set; }

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

            //modelBuilder.Entity<Fronteira>()
            //    .HasKey(cc => new { cc.CidadeId, cc.CidadeFronteiraId });

            //modelBuilder.Entity<Fronteira>()
            //    .HasOne(cc => cc.Cidade);

            //modelBuilder.Entity<Fronteira>()
            //    .HasOne(cc => cc.CidadeFronteira);

            //modelBuilder.Entity<Cidade>()
            //            .HasMany(x => x.Fronteiras)
            //            .WithOne(x => x.CidadeFronteira)
            //            .HasForeignKey(x => x.CidadeFronteiraId)
            //            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cidade>()
                        .HasOne(x => x.Estado);

            //modelBuilder.ApplyConfiguration(new LoginMapping());

        }

        private void ConfigurarCidade(ModelBuilder modelBuilder)
        {
        }

        private void ConfigurarEstado(ModelBuilder modelBuilder)
        {

        }

        private void ConfigurarUser(ModelBuilder modelBuilder)
        {

        }
    }
}
