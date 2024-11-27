using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Fornecedor;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Services;
using Serilog;

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
                Log.Information("Cadastrando fornecedor");
                Fornecedor fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

                bool fornecedorUnico = await _apiService.VerificaUnicoFornecedor(fornecedor);
                if (fornecedorUnico)
                {
                    await _context.Fornecedores.AddAsync(fornecedor);
                    await _context.SaveChangesAsync();

                    Log.Information("Dados cadastrados do fornecedor: {@fornecedor}", fornecedor);
                    return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
                }

                Log.Warning("CNPJ informado para o fornecedor já existe no banco de dados");
                return BadRequest("CNPJ cadastrado para outro fornecedor");


            }
            catch (Exception)
            {
                Log.Error("Falha em criar o fornecedor: {@fornecedorDto}", fornecedorDto);
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ReadFornecedorDto> ReadFornecedor([FromQuery] int pageNumber = 1, int pageQtd = 10)
        {
            try
            {
                Log.Information("Listando fornecedores do banco de dados, pagina {@pageNumber} com {@pageQtd} elementos por pagina", pageNumber, pageQtd);
                List<ReadFornecedorDto> fornecedores = new List<ReadFornecedorDto>();
                for (int i = (pageNumber - 1) * pageQtd; i < ((pageNumber - 1) * pageQtd) + pageQtd; i++)
                {
                    var fornecedor = _context.Fornecedores.FirstOrDefault(fornecedor => fornecedor.Id == i);
                    if (fornecedor != null)
                    {
                        var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);
                        fornecedores.Add(fornecedorDto);
                    }
                }

                return fornecedores;
            }
            catch (Exception)
            {
                Log.Error("Falha em listar os fornecedores");
                throw;
            }
        }


        [Authorize]
        [HttpGet("PesquisaCNPJ/{cnpj}")]
        public async Task<IActionResult> ReadFornecedorCNPJ(string cnpj)
        {
            try
            {
                Log.Information("Buscando fornecedor pelo CNPJ: {@cnpj}", cnpj);
                Fornecedor fornecedor = null;

                fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Cnpj == cnpj);
                
                if (fornecedor == null)
                {
                    Log.Warning("Não encontrado fornecedor com o CNPJ: {@cnpj}", cnpj);
                    return NotFound();
                }

                var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);

                Log.Information("Fornecedor encontrado: {@fornecedorDto}", fornecedorDto);
                return Ok(fornecedorDto);
            }
            catch (Exception)
            {
                Log.Error("Falha em buscar o fornecedor com o CNPJ: {@cnpj}", cnpj);
                throw;
            }
        }


        [Authorize]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> GetFornecedor(int id)
        {
            try
            {
                Log.Information("Buscando fornecedor pelo ID: {@id}", id);
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (fornecedor == null)
                {
                    Log.Warning("Não encontrado fornecedor com ID: {@id}", id);
                    return NotFound();
                }

                var fornecedorDto = _mapper.Map<ReadFornecedorDto>(fornecedor);

                Log.Information("Fornecedor encontrado: {@fornecedorDto}", fornecedorDto);
                return Ok(fornecedorDto);
            }
            catch (Exception) 
            {
                Log.Error("Falha em buscar o fornecedor pelo ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> UpdateFornecedor(int id, [FromBody] UpdateFornecedorDto fornecedorDto)
        {
            try
            {
                Log.Information("Atualizando dados do fornecedor com ID: {@id}", id);
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (fornecedor == null)
                {
                    Log.Warning("Não encontrado fornecedor com ID: {@id}", id);
                    return NotFound();
                }


                Log.Information("Dados do fornecedor foram atualizados, dados antigos: {@fornecedorDto}", fornecedorDto);
                _mapper.Map(fornecedorDto, fornecedor);
               await _context.SaveChangesAsync();

                Log.Information("Dados do fornecedor foram atualizados, dados novos: {@fornecedor}", fornecedor);
                return NoContent();
            }
            catch (Exception)
            {
                Log.Error("Falha em atualizar os dados do fornecedor com ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            try
            {
                Log.Information("Deletando dados do fornecedor com ID: {@id}", id);
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (fornecedor == null)
                {
                    Log.Warning("Não encontrado fornecedor com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do fornecedor foram apagados, dados antigos: {@fornecedor}", fornecedor);
                _context.Fornecedores.Remove(fornecedor);
               await _context.SaveChangesAsync();

                Log.Information("Deletados com sucesso os dados do fornecedor com ID: {@id}", id);
                return Ok();
            }
            catch (Exception)
            {
                Log.Error("Falha em deletar os dados do fornecedor com ID: {@id}", id);
                throw;
            }
        }
    }       
}
