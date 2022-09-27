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

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("ENDERECO").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnType("integer");
                entity.Property(x => x.Logradouro).HasColumnType("varchar(256)");
                entity.Property(x => x.Numero).HasColumnType("integer");
                entity.Property(x => x.Cep).HasColumnType("integer");
                entity.Property(x => x.Bairro).HasColumnType("varchar(50)");
                entity.Property(x => x.Cidade).HasColumnType("varchar(30)");
                entity.Property(x => x.Estado).HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("PESSOA").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnType("integer");
                entity.Property(x => x.Nome).HasColumnType("varchar(256)");
                entity.Property(x => x.Cpf).HasColumnType("bigint");
                entity.Property(x => x.EnderecoId).HasColumnType("integer");
            });

            modelBuilder.Entity<PessoaTelefone>(entity =>
            {
                entity.ToTable("PESSOA_TELEFONE");
                entity.Property(x => x.PessoaId).HasColumnName("ID_PESSOA").HasColumnType("integer");
                entity.Property(x => x.TelefoneId).HasColumnName("ID_TELEFONE").HasColumnType("integer");
                entity.HasKey(x => new { x.PessoaId, x.TelefoneId });
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.ToTable("TELEFONE").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnType("integer");
                entity.Property(x => x.Numero).HasColumnType("integer");
                entity.Property(x => x.ddd).HasColumnType("integer");
                entity.Property(x => x.TipoTelefoneId).HasColumnType("integer");
            });

            modelBuilder.Entity<TipoTelefone>(entity =>
            {
                entity.ToTable("TELEFONE_TIPO").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnType("integer");
                entity.Property(x => x.Tipo).HasColumnType("varchar(10)");
            });

        }
    }
}
