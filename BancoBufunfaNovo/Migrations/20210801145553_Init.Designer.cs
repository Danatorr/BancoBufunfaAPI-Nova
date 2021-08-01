﻿// <auto-generated />
using BancoBufunfaNovo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BancoBufunfaNovo.Migrations
{
    [DbContext(typeof(BancoBufunfaNovoContext))]
    [Migration("20210801145553_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("BancoBufunfaNovo.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cpf")
                        .HasColumnType("int");

                    b.Property<string>("Titular")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("BancoBufunfaNovo.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("NumeroConta")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.Property<string>("TipoDeConta")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clienteId");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("BancoBufunfaNovo.Models.Conta", b =>
                {
                    b.HasOne("BancoBufunfaNovo.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
