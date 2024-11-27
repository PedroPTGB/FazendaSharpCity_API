using AutoMapper;
using FazendaSharpCity_API.Authorization;
using FazendaSharpCity_API.Data.Contexts;
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
    public class VendaController : Controller
    {
        private ApiContext _context;
        private IMapper _mapper;
        public VendaController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CreateVenda([FromBody] CreateVendaDto vendaDto)
        {
            try
            {
                Log.Information("Cadastrando venda");
                Venda venda = _mapper.Map<Venda>(vendaDto);

                await _context.Vendas.AddAsync(venda);
                await _context.SaveChangesAsync();

                Log.Information("Dados cadastrados da venda: {@venda}", venda);
                return CreatedAtAction(nameof(GetVenda), new { id = venda.IdVenda }, venda.IdVenda);
            }
            catch (Exception)
            {
                Log.Error("Falha em criar a venda: {@vendaDto}", vendaDto);
                throw;
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public IEnumerable<ReadVendaDto> ListaVendas([FromQuery] int pageNumber = 1, int pageQtd = 10)
        {
            Log.Information("Listando vendas do banco de dados");
            return _mapper.Map<IEnumerable<ReadVendaDto>>(_context.Vendas.Skip((pageNumber - 1) * pageQtd).Take(pageQtd));
        }

        [Authorize]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> GetVenda(int id)
        {
            try
            {
                Log.Information("Buscando venda pelo ID: {@id}", id);
                var venda = await _context.Vendas.FirstOrDefaultAsync(venda => venda.IdVenda == id);

                if (venda == null)
                {
                    Log.Warning("Não encontrada venda com ID: {@id}", id);
                    return NotFound();
                }

                var vendaDto = _mapper.Map<ReadVendaDto>(venda);

                Log.Information("Venda encontrada: {@vendaDto}", vendaDto);
                return Ok(vendaDto);
            }
            catch (Exception)
            {
                Log.Error("Falha em buscar o venda pelo ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> UpdateVendaDto(int id, [FromBody] UpdateVendaDto vendaDto)
        {
            try
            {
                Log.Information("Atualizando dados da venda com ID: {@id}", id);
                var venda = await _context.Vendas.FirstOrDefaultAsync(venda => venda.IdVenda == id);

                if (venda == null)
                {
                    Log.Warning("Não encontrado venda com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados da venda foram atualizados, dados antigos: {@vendaDto}", vendaDto);
                _mapper.Map(vendaDto, venda);
                await _context.SaveChangesAsync();

                Log.Information("Dados da venda foram atualizados, dados novos: {@venda}", venda);
                return NoContent();
            }
            catch (Exception)
            {
                Log.Error("Falha em atualizar os dados da venda com ID: {@id}", id);
                throw;
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            try
            {
                Log.Information("Deletando dados da venda com ID: {@id}", id);
                var venda = await _context.Vendas.FirstOrDefaultAsync(venda => venda.IdVenda == id);

                if (venda == null)
                {
                    Log.Warning("Não encontrada venda com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados da venda foram apagados, dados antigos: {@venda}", venda);
                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();

                Log.Information("Deletados com sucesso os dados da venda com ID: {@id}", id);
                return Ok();
            }
            catch (Exception)
            {
                Log.Error("Falha em deletar os dados da venda com ID: {@id}", id);
                throw;
            }
        }
    }
}

