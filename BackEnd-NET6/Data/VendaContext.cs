using BackEnd_NET6.Models;
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
    }
}
