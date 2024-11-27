using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Endereco;
using FazendaSharpCity_API.Data.DTOs.Produto;
using FazendaSharpCity_API.Data.DTOs.Venda;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

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

        [Authorize]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoDto createProdutoDto)
        {
            try
            {
                Log.Information("Cadastrando produto");
                Produto produto = _mapper.Map<Produto>(createProdutoDto);
                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();

                Log.Information("Dados cadastrados do produto: {@produto}", produto);
                return CreatedAtAction(nameof(GetProduto), new { id = produto.IdProduto }, produto.IdProduto);

            }
            catch (Exception e)
            {
                Log.Error("Falha em criar o produto: {@createProdutoDto}", createProdutoDto);
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ReadProdutoDto> ListaProdutos([FromQuery] int pageNumber = 1, int pageQtd = 10)
        {
            Log.Information("Listando produtos do banco de dados");
            return _mapper.Map<IEnumerable<ReadProdutoDto>>(_context.Produtos.Skip((pageNumber - 1) * pageQtd).Take(pageQtd));
        }

        [Authorize]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            try
            {
                Log.Information("Buscando produto pelo ID: {@id}", id);
                var produto = await _context.Produtos.FindAsync(id);

                if (produto == null)
                {
                    Log.Warning("Não encontrado produto com ID: {@id}", id);
                    return NotFound();
                }

                var produtoDto = _mapper.Map<ReadProdutoDto>(produto);

                Log.Information("Produto encontrado: {@produtoDto}", produtoDto);
                return Ok(produtoDto);

            }
            catch (Exception)
            {
                Log.Error("Falha em buscar o produto pelo ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            try
            {
                Log.Information("Atualizando dados do produto com ID: {@id}", id);
                var produto = await _context.Produtos.FirstOrDefaultAsync(produto => produto.IdProduto == id);

                if (produto == null)
                {
                    Log.Warning("Não encontrado produto com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do produto foram atualizados, dados antigos: {@produtoDto}", produtoDto);
                _mapper.Map(produtoDto, produto);
               await _context.SaveChangesAsync();

                Log.Information("Dados do produto foram atualizados, dados novos: {@produto}", produto);
                return Ok();
            }
            catch (Exception)
            {
                Log.Error("Falha em atualizar os dados do produto com ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                Log.Information("Deletando dados do produto com ID: {@id}", id);
                var produto = await _context.Produtos.FirstOrDefaultAsync(produto => produto.IdProduto == id);

                if (produto == null)
                {
                    Log.Warning("Não encontrado produto com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do produto foram apagados, dados antigos: {@produto}", produto);
                _context.Produtos.Remove(produto);
               await _context.SaveChangesAsync();

                Log.Information("Deletados com sucesso os dados do produto com ID: {@id}", id);
                return Ok();
            }
            catch (Exception)
            {
                Log.Error("Falha em deletar os dados do produto com ID: {@id}", id);
                throw;
            }
        }
    }
}
