// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_my_bank_dotnet.Data;

namespace api_my_bank_dotnet.Migrations
{
  [DbContext(typeof(DataContext))]
  [Migration("20220114113355_user")]
  partial class user
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
        .HasAnnotation("Relational:MaxIdentifierLength", 64)
        .HasAnnotation("ProductVersion", "5.0.13");

      modelBuilder.Entity("api_my_bank_dotnet.Models.User", b =>
      {
        b.Property<ulong>("user_id")
          .ValueGeneratedOnAdd()
          .HasColumnType("bigint unsigned");

        b.Property<ulong>("bank_account_id")
          .HasColumnType("bigint unsigned");

        b.Property<string>("full_name")
          .IsRequired()
          .HasMaxLength(255)
          .HasColumnType("varchar(255)");

        b.Property<string>("surname")
          .IsRequired()
          .HasMaxLength(20)
          .HasColumnType("varchar(20)");

        b.Property<string>("login")
          .IsRequired()
          .HasMaxLength(15)
          .HasColumnType("varchar(15)");

        b.Property<string>("email")
          .IsRequired()
          .HasMaxLength(100)
          .HasColumnType("varchar(100)");

        b.Property<string>("password")
          .IsRequired()
          .HasMaxLength(100)
          .HasColumnType("varchar(100)");

        b.Property<string>("passport_number")
         .IsRequired()
         .HasMaxLength(9)
         .HasColumnType("varchar(9)");

        b.Property<int>("age")
          .HasColumnType("int");

        b.Property<string>("gender")
         .IsRequired()
         .HasMaxLength(20)
         .HasColumnType("varchar(20)");

        b.Property<string>("civil_status")
          .IsRequired()
          .HasMaxLength(20)
          .HasColumnType("varchar(20)");

        b.Property<DateTime>("birth_date")
          .HasColumnType("date");

        b.Property<DateTime>("created_at")
          .HasColumnType("datetime");

        b.Property<DateTime>("updated_at")
          .HasColumnType("datetime");

        b.HasKey("user_id");

        b.HasIndex("bank_account_id")
          .IsUnique();

        b.HasIndex("login")
          .IsUnique();

        b.HasIndex("email")
          .IsUnique();

        b.HasIndex("passport_number")
          .IsUnique();

        b.ToTable("user");
      });

      modelBuilder.Entity("api_my_bank_dotnet.Models.User", b =>
      {
        b.HasOne("api_my_bank_dotnet.Models.BankAccount", "bankAccount")
          .WithOne("user")
          .HasForeignKey("api_my_bank_dotnet.Models.User", "bank_account_id")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();

        b.Navigation("bankAccount");
      });

      modelBuilder.Entity("api_my_bank_dotnet.Models.BankAccount", b =>
      {
        b.Navigation("user");
      });
#pragma warning restore 612, 618
    }
  }
}