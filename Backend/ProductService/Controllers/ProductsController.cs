using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;
using System.Collections.Generic;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        /*private readonly ProductContext _context;

        public ProductsController(ProductContext productContext)
        {
            _context = productContext;
        }*/

        private static readonly List<Product> _productos = new List<Product>
        {
            new Product{ Id= 1, Name = "Transferencias", Price= 0.00},
            new Product{ Id= 2, Name = "Pago de servicios", Price= 0.41},
            new Product{ Id= 3, Name = "Pedir una nueva tarjeta", Price= 5}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_productos); 
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            /*var productoF = New Product { Id= id, Name = "Producto", Price= 99.99}
            return Ok(productoF);*/
            var producto = -productos.Fin(p=> p.id == id); 
            if (producto == null) return NotFound();
            return Ok(productos);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product producto)
        {
            producto.Id = _productos.Count + 1;
            _productos.Add(producto); 
            //await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product producto)
        {
            var index = _productos.FindIndex(p => p.Id == id);
            if(index== -1){
                return NotFound();
            }
            _productos[index]=producto;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var producto = -productos.Fin(p=> p.id == id);
            if (producto == null) return NotFound();

            _productos.Remove(producto);
            return NoContent();
        }
    }
}
