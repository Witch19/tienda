using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TransactionsService.Data;
using TransactionsService.Models;

namespace TransactionsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsContext _context;
        private readonly HttpClient _httpClient;

        public TransactionsController(TransactionsContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient("ProductService");
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _httpClient.GetAsync(""); // Llama a ProductService
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener productos");
            }

            var products = await response.Content.ReadAsStringAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Transaccion>> CreateTransaction(Transaccion transaccion)
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener productos");
            }

            var productsJson = await response.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<Producto>>(productsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var productoSeleccionado = productos?.FirstOrDefault();

            if (productoSeleccionado == null)
            {
                return BadRequest("No hay productos disponibles.");
            }

            transaccion.TipoTransaccion = productoSeleccionado.Name;

            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaccion.Id }, transaccion);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> GetTransactions()
        {
            return await _context.Transacciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaccion>> GetTransaction(int id)
        {
            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion == null) return NotFound();
            return transaccion;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, Transaccion transaccion)
        {
            if (id != transaccion.Id) return BadRequest();

            _context.Entry(transaccion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion == null) return NotFound();

            _context.Transacciones.Remove(transaccion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
