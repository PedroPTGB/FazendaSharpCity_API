using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Endereco;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
                Log.Information("Cadastrando endereco");
                Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

                await _context.Enderecos.AddAsync(endereco);
                await _context.SaveChangesAsync();

                Log.Information("Dados cadastrados do endereco: {@endereco}", endereco);
                return CreatedAtAction(nameof(ReadEndereco), new { Id = endereco.Id }, endereco);
            }
            catch (Exception)
            {
                Log.Error("Falha em criar o endereco: {@enderecoDto}", enderecoDto);
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaEnderecos()
        {
            Log.Information("Listando enderecos do banco de dados");
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
        }

        [Authorize]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> ReadEndereco(int id)
        {
            try
            {
                Log.Information("Buscando endereco pelo ID: {@id}", id);
                Endereco endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);

                if (endereco != null)
                {
                    ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                    Log.Information("Endereco encontrado: {@endereco}", enderecoDto);
                    return Ok(enderecoDto);
                }
                Log.Warning("Não encontrado endereco com ID: {@id}", id);
                return NotFound();
            }
            catch (Exception)
            {
                Log.Error("Falha em buscar o endereco pelo ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> UpdateEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            try
            {
                Log.Information("Atualizando dados do endereco com ID: {@id}", id);
                Endereco endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);

                if (endereco == null)
                {
                    Log.Warning("Não encontrado endereco com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do endereco foram atualizados, dados antigos: {@enderecoDto}", enderecoDto);
                _mapper.Map(enderecoDto, endereco);
                await _context.SaveChangesAsync();

                Log.Information("Dados do endereco foram atualizados, dados novos: {@endereco}", endereco);
                return NoContent();
            }            
            catch (Exception)
            {
                Log.Error("Falha em atualizar os dados do endereco com ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> DeletaEndereco(int id)
        {
            try
            {
                Log.Information("Deletando dados do endereco com ID: {@id}", id);
                Endereco endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);

                if (endereco == null)
                {
                    Log.Warning("Não encontrado endereco com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do endereco foram apagados, dados antigos: {@endereco}", endereco);
                _context.Remove(endereco);
                await _context.SaveChangesAsync();

                Log.Information("Deletados com sucesso os dados do endereco com ID: {@id}", id);
                return NoContent();
            }
            catch (Exception)
            {
                Log.Error("Falha em deletar os dados do endereco com ID: {@id}", id);
                throw;
            }
        }

    }
}


