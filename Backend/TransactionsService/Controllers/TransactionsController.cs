using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionsService.Data;
using TransactionsService.Models;

namespace TransactionsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsContext _context;

        public TransactionsController(TransactionsContext transactionContext)
        {
            _context = transactionContext;
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

        [HttpPost]
        public async Task<ActionResult<Transaccion>> CreateTransaction(Transaccion transaccion) 
        {
            _context.Transacciones.Add(transaccion); 
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransaction), new { id = transaccion.Id }, transaccion); 
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
}
