using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Fornecedor;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : Controller
    {
        private ApiContext _context;
        private IMapper _mapper;

        public FornecedorController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFornecedor([FromBody] CreateFornecedorDto fornecedorDto)
        {
            try
            {
                Fornecedor fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

                if (fornecedor == null)
                {
                    return BadRequest("Fornecedor não pode ser nulo.");
                }

                await _context.Fornecedores.AddAsync(fornecedor);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFornecedor(int id)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (fornecedor == null)
                {
                    return NotFound();
                }
                else
                {
                    var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);

                    return Ok(fornecedorDto);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFornecedor(int id, [FromBody] UpdateFornecedorDto fornecedorDto)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (fornecedor == null)
                {
                    return NotFound();
                }

                _mapper.Map(fornecedorDto, fornecedor);
               await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (fornecedor == null)
                {
                    return NotFound();
                }

                _context.Fornecedores.Remove(fornecedor);
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
