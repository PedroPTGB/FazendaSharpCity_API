using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Venda;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<IActionResult> CreateVenda([FromBody] CreateVendaDto vendaDto)
        {
            try
            {
                Venda venda = _mapper.Map<Venda>(vendaDto);

                if (venda == null)
                {
                    return BadRequest("Venda não pode ser nulo.");
                }

                await _context.Vendas.AddAsync(venda);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVenda), new { id = venda.IdVenda }, venda.IdVenda);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<ReadVendaDto> ListaVendas([FromQuery] int pageNumber = 1, int pageQtd = 10)
        {
            return _mapper.Map<IEnumerable<ReadVendaDto>>(_context.Vendas.Skip((pageNumber - 1) * pageQtd).Take(pageQtd));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenda(int id)
        {
            try
            {
                var venda = await _context.Vendas.FirstOrDefaultAsync(venda => venda.IdVenda == id);

                if (venda == null)
                {
                    return NotFound();
                }

                var vendaDto = _mapper.Map<ReadVendaDto>(venda);

                return Ok(vendaDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVendaDto(int id, [FromBody] UpdateVendaDto vendaDto)
        {
            try
            {
                var venda = await _context.Vendas.FirstOrDefaultAsync(venda => venda.IdVenda == id);

                if (venda == null)
                {
                    return NotFound();
                }

                _mapper.Map(vendaDto, venda);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            try
            {
                var venda = await _context.Vendas.FirstOrDefaultAsync(venda => venda.IdVenda == id);

                if (venda == null)
                {
                    return NotFound();
                }

                _context.Vendas.Remove(venda);
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

