﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_my_bank_dotnet.Data;

namespace api_my_bank_dotnet.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("api_my_bank_dotnet.Entities.Address", b =>
                {
                    b.Property<ulong>("address_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("address_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("complement")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<ulong>("user_id")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("address_id");

                    b.HasIndex("user_id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("api_my_bank_dotnet.Entities.BankAccount", b =>
                {
                    b.Property<ulong>("bank_account_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("account_number")
                        .HasColumnType("bigint unsigned");

                    b.Property<uint>("branch_number")
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("currency")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<ulong>("monthly_income")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("bank_account_id");

                    b.HasIndex("account_number")
                        .IsUnique();

                    b.ToTable("bank_account");
                });

            modelBuilder.Entity("api_my_bank_dotnet.Entities.User", b =>
                {
                    b.Property<ulong>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<ulong>("bank_account_id")
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime>("birth_date")
                        .HasColumnType("date");

                    b.Property<string>("civil_status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("passport_number")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.HasKey("user_id");

                    b.HasIndex("bank_account_id")
                        .IsUnique();

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("login")
                        .IsUnique();

                    b.HasIndex("passport_number")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("api_my_bank_dotnet.Entities.Address", b =>
                {
                    b.HasOne("api_my_bank_dotnet.Entities.User", "user")
                        .WithMany("addresses")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_my_bank_dotnet.Entities.User", b =>
                {
                    b.HasOne("api_my_bank_dotnet.Entities.BankAccount", "bankAccount")
                        .WithOne("user")
                        .HasForeignKey("api_my_bank_dotnet.Entities.User", "bank_account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bankAccount");
                });

            modelBuilder.Entity("api_my_bank_dotnet.Entities.BankAccount", b =>
                {
                    b.Navigation("user");
                });

            modelBuilder.Entity("api_my_bank_dotnet.Entities.User", b =>
                {
                    b.Navigation("addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
