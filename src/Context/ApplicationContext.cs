using E_Commerce_CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_CasaDoCodigo.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(x => x.Id);
            
            modelBuilder.Entity<Pedido>().HasKey(x => x.Id);
            modelBuilder.Entity<Pedido>().HasMany(x => x.Itens).WithOne(x => x.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(x => x.Cadastro).WithOne(x => x.Pedido).HasForeignKey<Cadastro>(x => x.Id).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(x => x.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(x => x.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(x => x.Produto);
            
            modelBuilder.Entity<Cadastro>().HasKey(x => x.Id);
            modelBuilder.Entity<Cadastro>().HasOne(x => x.Pedido);
        }
    }
}
