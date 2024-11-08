using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Produto;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private ProdutoContext _context;
        private IMapper _mapper;

        public ProdutoController(Produto context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult>CreateProduto([FromBody] CreateProdutoDto createProdutoDto)
        {
            Produto produto = _mapper.Map<Produto>(createProdutoDto);

            if (produto == null) 
            {
                return BadRequest("O produto não pode ser nulo");
            }

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.IdProduto }, produto.IdProduto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if(produto == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(produto);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            var produto = _context.Produtos.FirstOrDefault(produto => produto.IdProduto == id);

            if(produto == null)
            {
                return NotFound();
            }

            _mapper.Map(produtoDto, produto);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(produto => produto.IdProduto == id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok();
        }
    }
}
