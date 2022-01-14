using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_my_bank_dotnet.Entities
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Endereco> Endereco { get; set; }

    //public DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Endereço
      modelBuilder.Entity<Endereco>()
        .ToTable("endereco");

      modelBuilder.Entity<Endereco>()
        .HasKey(e => e.endereco_id);

      modelBuilder.Entity<Endereco>()
        .Property(e => e.endereco_id)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.uf)
        .HasMaxLength(2)
        .IsRequired();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.cep)
        .HasMaxLength(8)
        .IsRequired();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.logradouro)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.numero)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.complemento)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.bairro)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.cidade)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.created_at)
        .HasColumnType("datetime")
        .IsRequired();

      modelBuilder.Entity<Endereco>()
        .Property(e => e.updated_at)
        .HasColumnType("datetime")
        .IsRequired();

      /*
      // Usuário
      modelBuilder.Entity<Usuario>()
        .ToTable("usuario");

      modelBuilder.Entity<Usuario>()
        .HasKey(u => u.usuario_id);

      // Entity Framework não tem o on update da fk
      modelBuilder.Entity<Endereco>()
        .HasOne(e => e.usuario)
        .WithOne(u => u.endereco)
        .HasForeignKey<Usuario>(u => u.endereco_id)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Usuario>()
        .Property(u => u.nome_completo)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.apelido)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.rg)
        .HasMaxLength(9)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.cpf)
        .HasMaxLength(11)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.idade)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.sexo)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.estado_civil)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.data_nascimento)
        .HasColumnType("date")
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.renda_mensal)
        .HasColumnType("bigint")
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(e => e.created_at)
        .HasColumnType("datetime")
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(e => e.updated_at)
        .HasColumnType("datetime")
        .IsRequired();
      */
    }
  }
}