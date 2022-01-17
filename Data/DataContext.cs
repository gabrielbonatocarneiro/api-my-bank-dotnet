using System.ComponentModel.DataAnnotations.Schema;
using api_my_bank_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_my_bank_dotnet.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Endereco> Endereco { get; set; }

    public DbSet<Usuario> Usuario { get; set; }

    public DbSet<ContaBancaria> ContaBancaria { get; set; }

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

      // Conta Bancária
      modelBuilder.Entity<ContaBancaria>()
        .ToTable("conta_bancaria");

      modelBuilder.Entity<ContaBancaria>()
        .HasKey(c => c.conta_bancaria_id);

      modelBuilder.Entity<ContaBancaria>()
        .Property(c => c.conta_bancaria_id)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<ContaBancaria>()
        .Property(c => c.num_agencia)
        .IsRequired();

      modelBuilder.Entity<ContaBancaria>()
        .Property(c => c.num_conta_corrente)
        .IsRequired();

      modelBuilder.Entity<ContaBancaria>()
        .HasIndex(c => c.num_conta_corrente)
        .IsUnique();

      modelBuilder.Entity<ContaBancaria>()
        .Property(c => c.created_at)
        .HasColumnType("datetime")
        .IsRequired();

      // Usuário
      modelBuilder.Entity<Usuario>()
        .ToTable("usuario");

      modelBuilder.Entity<Usuario>()
        .HasKey(u => u.usuario_id);

      modelBuilder.Entity<Usuario>()
        .Property(c => c.usuario_id)
        .ValueGeneratedOnAdd();

      /*
        Entity Framework não tem o on update da fk
        FK de endereco_id
      */
      modelBuilder.Entity<Endereco>()
        .HasOne(e => e.usuario)
        .WithOne(u => u.endereco)
        .HasForeignKey<Usuario>(u => u.endereco_id)
        .OnDelete(DeleteBehavior.Cascade);

      /*
        Entity Framework não tem o on update da fk
        FK de conta_bancaria_id
      */
      modelBuilder.Entity<ContaBancaria>()
        .HasOne(c => c.usuario)
        .WithOne(u => u.contaBancaria)
        .HasForeignKey<Usuario>(u => u.conta_bancaria_id)
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
        .Property(u => u.login)
        .HasMaxLength(15)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
       .HasIndex(c => c.login)
       .IsUnique();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.email)
        .HasMaxLength(100)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
       .HasIndex(u => u.email)
       .IsUnique();

      modelBuilder.Entity<Usuario>()
       .Property(u => u.senha)
       .HasMaxLength(100)
       .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.rg)
        .HasMaxLength(9)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .HasIndex(u => u.rg)
        .IsUnique();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.cpf)
        .HasMaxLength(11)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .HasIndex(u => u.cpf)
        .IsUnique();

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
        .Property(u => u.renda_mensal)
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(u => u.data_nascimento)
        .HasColumnType("date")
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(e => e.created_at)
        .HasColumnType("datetime")
        .IsRequired();

      modelBuilder.Entity<Usuario>()
        .Property(e => e.updated_at)
        .HasColumnType("datetime")
        .IsRequired();
    }
  }
}