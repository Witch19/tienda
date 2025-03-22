using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class Product
    {
        public int Id {get;set;}
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public decimal Price { get; set; } 
        public int Stock {get;set;}
    }

}