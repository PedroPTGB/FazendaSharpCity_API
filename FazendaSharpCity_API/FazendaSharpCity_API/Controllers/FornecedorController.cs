using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Fornecedor;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Services;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : Controller
    {
        private ApiContext _context;
        private IMapper _mapper;
        private ApiService _apiService;

        public FornecedorController(ApiContext context, IMapper mapper, ApiService apiService)
        {
            _context = context;
            _mapper = mapper;
            _apiService = apiService;
        }

        [Authorize]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CreateFornecedor([FromBody] CreateFornecedorDto fornecedorDto)
        {
            try
            {
                Fornecedor fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

                bool fornecedorUnico = await _apiService.VerificaUnicoFornecedor(fornecedor);
                if (fornecedorUnico)
                {
                    await _context.Fornecedores.AddAsync(fornecedor);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
                }

                return BadRequest("CNPJ cadastrado para outro fornecedor");


            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ReadFornecedorDto> ReadFornecedor([FromQuery] int pageNumber = 1, int pageQtd = 10, string? nome = null)
        {
            try
            {

                List<ReadFornecedorDto> fornecedores = new List<ReadFornecedorDto>();
                for (int i = pageNumber - 1; i < pageQtd; i++)
                {

                    if (nome == null)
                    {
                        var fornecedor = _context.Fornecedores.FirstOrDefault(fornecedor => fornecedor.Id == i);
                        if (fornecedor != null)
                        {
                            var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);
                            fornecedores.Add(fornecedorDto);
                        }
                    }
                    else
                    {
                        var fornecedor = _context.Fornecedores.Where(fornecedor => fornecedor.RazaoSocial.Contains(nome));
                        if (fornecedor != null)
                        {
                            var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);
                            fornecedores.Add(fornecedorDto);
                        }
                    }
                }

                return fornecedores;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Authorize]
        [HttpGet("PesquisaCNPJ/{cnpj}")]
        public async Task<IActionResult> ReadFornecedorCNPJ(string cnpj)
        {
            try
            {
                Fornecedor fornecedor = null;

                fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Cnpj == cnpj);
                
                if (fornecedor == null)
                {
                    return NotFound();
                }

                var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);

                return Ok(fornecedorDto);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Authorize]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> GetFornecedor(int id)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (fornecedor == null)
                {
                    return NotFound();
                }

                var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);

                return Ok(fornecedorDto);
            }
            catch (Exception) 
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut("Atualizar/{id}")]
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

        [Authorize]
        [HttpDelete("Excluir/{id}")]
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
