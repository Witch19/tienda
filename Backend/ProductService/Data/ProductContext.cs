using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options){ }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().HasData(
                new Product{ Id = 1, Name = "Transferencias", Descripcion = "Aqui puedes pasar tu dinero sin costo", Price = 0.00M },
                new Product{ Id = 2, Name = "Pago de servicios", Descripcion = "Paga todo lo de tu casita", Price = 0.41M },
                new Product{ Id = 3, Name = "Pedir una nueva tarjeta", Descripcion = "Si se te perdió, adquiere otra", Price = 5M, Stock = 10 }
            );
        }
    }
}