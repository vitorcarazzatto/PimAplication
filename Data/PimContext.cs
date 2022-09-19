using Microsoft.EntityFrameworkCore;
using PimAplication.Models.Entities;

namespace PimAplication.Data
{
    public class PimContext : DbContext
    {
        public PimContext(DbContextOptions<PimContext> options) : base(options) { }

        public DbSet<Endereco> ?Enderecos { get; set; }
        public DbSet<Pessoa> ?Pessoas { get; set; }
        public DbSet<PessoaTelefone> ?PessoaTelefones { get; set; }
        public DbSet<Telefone> ?Telefones{ get; set; }
        public DbSet<TipoTelefone> ?TipoTelefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
