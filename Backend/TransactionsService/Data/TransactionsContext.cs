using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionsService.Models;

namespace TransactionsService.Data
{
    public class TransactionsContext : DbContext
    {
        public TransactionsContext(DbContextOptions<TransactionsContext> options) : base(options) { }

        public DbSet<Transaccion> Transacciones { get; set; }  
    }
}