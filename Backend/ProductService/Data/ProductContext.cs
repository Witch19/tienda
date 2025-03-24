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
                new Product{ Id= 1, Name = "Transferencias", Price= 0.00},
                new Product{ Id= 2, Name = "Pago de servicios", Price= 0.41},
                new Product{ Id= 3, Name = "Pedir una nueva tarjeta", Price= 5}
            );
        }
    }
}