using FazendaSharpCity_API.Data;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FazendaSharpCity_API.Controllers
{
    public class FornecedorController : Controller
    {
        private FornecedorContext _context;

        public FornecedorController(FornecedorContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarFornecedor([FromBody] Fornecedor fornecedor)
        {
            if(fornecedor == null)
            {
                return BadRequest("Fornecedor não pode ser nulo.");
            }

            await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ConsultaFornecedor), new { id = fornecedor.Id }, fornecedor.Id);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);

            if(fornecedor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(fornecedor);
            }
        }
    }       
}
