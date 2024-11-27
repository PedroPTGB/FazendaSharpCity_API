using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Endereco;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private ApiContext _context;
        private IMapper _mapper;

        public EnderecoController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CreateEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            try
            {
                Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

                await _context.Enderecos.AddAsync(endereco);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(ReadEndereco), new { Id = endereco.Id }, endereco);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
        }

        [Authorize]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> ReadEndereco(int id)
        {
            try
            {
                Endereco endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);

                if (endereco != null)
                {
                    ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                    return Ok(enderecoDto);
                }

                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> UpdateEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            try
            {
                Endereco endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);

                if (endereco == null)
                {
                    return NotFound();
                }

                _mapper.Map(enderecoDto, endereco);
                await _context.SaveChangesAsync();

                return NoContent();
            }            
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaEndereco(int id)
        {
            try
            {
                Endereco endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);

                if (endereco == null)
                {
                    return NotFound();
                }

                _context.Remove(endereco);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}


