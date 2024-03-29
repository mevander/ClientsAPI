﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using ClientsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsAPI.Data;

public partial class ClientsContextDb : DbContext
{
    public ClientsContextDb(DbContextOptions<ClientsContextDb> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteEndereco> ClienteEnderecos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=clients-cnp.database.windows.net;Initial Catalog=ClientsBD;User Id=m.evander;Password=bur8tfftZ9B7bsc");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLIENTE");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DatInclusao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DAT_INCLUSAO");
            entity.Property(e => e.DtNascimento)
                .HasColumnType("datetime")
                .HasColumnName("DT_NASCIMENTO");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("NOME");
            entity.Property(e => e.Status).HasColumnName("STATUS");
        });

        modelBuilder.Entity<ClienteEndereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLIENTE_ENDERECO");

            entity.ToTable("CLIENTE_ENDERECOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("BAIRRO");
            entity.Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("CIDADE");
            entity.Property(e => e.DatInclusao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DAT_INCLUSAO");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("LOGRADOURO");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Uf)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("UF");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClienteEnderecos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CLIENTE_CLIENTE_ENDERECOS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}