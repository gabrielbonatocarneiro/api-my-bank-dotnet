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

    public DbSet<Address> Address { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<BankAccount> BankAccount { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Address
      modelBuilder.Entity<Address>()
        .ToTable("address");

      modelBuilder.Entity<Address>()
        .HasKey(a => a.address_id);

      modelBuilder.Entity<Address>()
        .Property(a => a.address_id)
        .ValueGeneratedOnAdd();

      /*
        Entity Framework haven't on update fk
        FK de address_id
      */
      modelBuilder.Entity<Address>()
        .HasOne(a => a.user)
        .WithMany(u => u.addresses)
        .HasForeignKey(a => a.user_id)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Address>()
        .Property(a => a.address_name)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Address>()
        .Property(a => a.number)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<Address>()
        .Property(a => a.complement)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Address>()
        .Property(a => a.district)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Address>()
        .Property(a => a.city)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Address>()
        .Property(a => a.state)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Address>()
        .Property(a => a.country)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<Address>()
        .Property(a => a.created_at)
        .HasColumnType("datetime")
        .IsRequired();

      modelBuilder.Entity<Address>()
        .Property(a => a.updated_at)
        .HasColumnType("datetime")
        .IsRequired();

      // Bank Account
      modelBuilder.Entity<BankAccount>()
        .ToTable("bank_account");

      modelBuilder.Entity<BankAccount>()
        .HasKey(ba => ba.bank_account_id);

      modelBuilder.Entity<BankAccount>()
        .Property(ba => ba.bank_account_id)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<BankAccount>()
        .Property(ba => ba.branch_number)
        .IsRequired();

      modelBuilder.Entity<BankAccount>()
        .Property(ba => ba.account_number)
        .IsRequired();

      modelBuilder.Entity<BankAccount>()
        .HasIndex(ba => ba.account_number)
        .IsUnique();

      modelBuilder.Entity<BankAccount>()
        .Property(ba => ba.currency)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<BankAccount>()
        .Property(ba => ba.monthly_income)
        .IsRequired();

      modelBuilder.Entity<BankAccount>()
        .Property(ba => ba.created_at)
        .HasColumnType("datetime")
        .IsRequired();

      // User
      modelBuilder.Entity<User>()
        .ToTable("user");

      modelBuilder.Entity<User>()
        .HasKey(u => u.user_id);

      modelBuilder.Entity<User>()
        .Property(u => u.user_id)
        .ValueGeneratedOnAdd();

      /*
        Entity Framework haven't on update fk
        FK de bank_account_id
      */
      modelBuilder.Entity<BankAccount>()
        .HasOne(ba => ba.user)
        .WithOne(u => u.bankAccount)
        .HasForeignKey<User>(u => u.bank_account_id)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<User>()
        .Property(u => u.full_name)
        .HasMaxLength(255)
        .IsRequired();

      modelBuilder.Entity<User>()
        .Property(u => u.surname)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<User>()
        .Property(u => u.login)
        .HasMaxLength(15)
        .IsRequired();

      modelBuilder.Entity<User>()
       .HasIndex(u => u.login)
       .IsUnique();

      modelBuilder.Entity<User>()
        .Property(u => u.email)
        .HasMaxLength(100)
        .IsRequired();

      modelBuilder.Entity<User>()
       .HasIndex(u => u.email)
       .IsUnique();

      modelBuilder.Entity<User>()
       .Property(u => u.password)
       .HasMaxLength(100)
       .IsRequired();

      modelBuilder.Entity<User>()
        .Property(u => u.passport_number)
        .HasMaxLength(9)
        .IsRequired();

      modelBuilder.Entity<User>()
        .HasIndex(u => u.passport_number)
        .IsUnique();

      modelBuilder.Entity<User>()
        .Property(u => u.age)
        .IsRequired();

      modelBuilder.Entity<User>()
        .Property(u => u.gender)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<User>()
        .Property(u => u.civil_status)
        .HasMaxLength(20)
        .IsRequired();

      modelBuilder.Entity<User>()
        .Property(u => u.birth_date)
        .HasColumnType("date")
        .IsRequired();

      modelBuilder.Entity<User>()
        .Property(e => e.created_at)
        .HasColumnType("datetime")
        .IsRequired();

      modelBuilder.Entity<User>()
        .Property(e => e.updated_at)
        .HasColumnType("datetime")
        .IsRequired();
    }
  }
}