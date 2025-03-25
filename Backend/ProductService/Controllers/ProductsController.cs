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
            new Product{ Id= 1, Name = "Transferencias", Descripcion = "Aqui puedes pasar tu dinero si costo", Price= 0.00M},
            new Product{ Id= 2, Name = "Pago de servicios", Descripcion = "Paga todo lo de tu casita", Price= 0.41M},
            new Product{ Id= 3, Name = "Pedir una nueva tarjeta", Descripcion = "Si se te perdio, adquiere otra", Price= 5M, Stock=10}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_productos); 
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var producto = _productos.Find(p => p.Id == id); 
            if (producto == null) return NotFound();
            return Ok(producto); 
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
            var producto = _productos.Find(p => p.Id == id); // Cambié de -productos.Fin a _productos.Find
            if (producto == null) return NotFound();

            _productos.Remove(producto);
            return NoContent();
        }
    }
}
