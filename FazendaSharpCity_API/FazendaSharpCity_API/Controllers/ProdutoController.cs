using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Endereco;
using FazendaSharpCity_API.Data.DTOs.Produto;
using FazendaSharpCity_API.Data.DTOs.Venda;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private ApiContext _context;
        private IMapper _mapper;

        public ProdutoController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoDto createProdutoDto)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(createProdutoDto);
                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProduto), new { id = produto.IdProduto }, produto.IdProduto);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<ReadProdutoDto> ListaProdutos([FromQuery] int pageNumber = 1, int pageQtd = 10)
        {
            return _mapper.Map<IEnumerable<ReadProdutoDto>>(_context.Produtos.Skip((pageNumber - 1) * pageQtd).Take(pageQtd));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(id);

                if (produto == null)
                {
                    return NotFound();
                }

                var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
                return Ok(produtoDto);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(produto => produto.IdProduto == id);

                if (produto == null)
                {
                    return NotFound();
                }

                _mapper.Map(produtoDto, produto);
               await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(produto => produto.IdProduto == id);

                if (produto == null)
                {
                    return NotFound();
                }

                _context.Produtos.Remove(produto);
               await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
