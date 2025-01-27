﻿using BackEnd_NET6.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_NET6.Data
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options)
        {
        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Plano> Planos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Vendedor)
                .WithMany(v => v.Vendas)
                .HasForeignKey(v => v.VendedorId);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Plano)
                .WithMany(v => v.Vendas)
                .HasForeignKey(v => v.PlanoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
