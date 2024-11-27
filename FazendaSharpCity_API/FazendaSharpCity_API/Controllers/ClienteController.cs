using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Models;
using FazendaSharpCity_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Diagnostics.Eventing.Reader;

namespace FazendaSharpCity_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private ApiContext _context;
        private IMapper _mapper;
        private ApiService _apiService;

        public ClienteController(ApiContext context, IMapper mapper, ApiService apiService)
        {
            _context = context;
            _mapper = mapper;
            _apiService = apiService;
        }

        [Authorize]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CreateClienteDto([FromBody] CreateClienteDto clienteDto)
        {
            try
            {
                Log.Information("Cadastrando cliente");
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);


                bool clienteUnico = await _apiService.VerificaUnicoCliente(cliente);

                if (clienteUnico)
                {
                    await _context.Clientes.AddAsync(cliente);
                    await _context.SaveChangesAsync();
                    
                    Log.Information("Dados cadastrados do cliente: {@cliente}", cliente);
                    return CreatedAtAction(nameof(ReadClienteId), new { id = cliente.Id }, cliente);
                }

                Log.Warning("Codigo fiscal informado para o cliente já existe no banco de dados");
                return BadRequest("CPF ou CNPJ cadastrado para outro cliente");
                    
            }
            catch (Exception)
            {
                Log.Error("Falha em criar o cliente: {@clienteDto}", clienteDto);
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ReadClienteDto> ReadCliente([FromQuery] int pageNumber = 1, int pageQtd = 10)
        {
            try
            {
                Log.Information("Listando Clientes do banco de dados, pagina {@pageNumber} com {@pageQtd} elementos por pagina", pageNumber, pageQtd );
                List<ReadClienteDto> clientes = new List<ReadClienteDto>();
                for (int i = (pageNumber-1)*pageQtd; i < ((pageNumber - 1) * pageQtd)+pageQtd; i++)
                {
                    var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == i);
                    if (cliente != null)
                    {
                        var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
                        clientes.Add(clienteDto);
                    }
                }

                return clientes;
            }
            catch (Exception)
            {
                Log.Error("Falha em listar os clientes");
                throw;
            }
        }


        [Authorize]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> ReadClienteId(int id) 
        {
            try
            {
                Log.Information("Buscando cliente pelo ID: {@id}", id);
                var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);

                if (cliente == null)
                {
                    Log.Warning("Não encontrado cliente com ID: {@id}", id);
                    return NotFound();
                }

                var clienteDto = _mapper.Map<ReadClienteDto>(cliente);

                Log.Information("Cliente encontrado: {@cliente}", clienteDto);
                return Ok(clienteDto);
            }
            catch (Exception)
            {
                Log.Error("Falha em buscar o cliente pelo ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpGet("PesquisaCPF-CNPJ/{cpf}")]
        public async Task<IActionResult> ReadClienteCPFeCNPJ(string cpf)
        {
            try
            {
                Cliente cliente = null;
                if(cpf.Length == 11)
                {
                    Log.Information("Buscando cliente pelo CPF: {@cpf}", cpf);
                    cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.CPF == cpf);
                }
                else if(cpf.Length == 13)
                {
                    Log.Information("Buscando cliente pelo CNPJ: {@cnpj}", cpf);
                    cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.CNPJ == cpf);
                }

                if (cliente == null)
                {
                    Log.Warning("Não encontrado cliente com o codigo fiscal: {@cpf}", cpf);
                    return NotFound();
                }

                var clienteDto = _mapper.Map<ReadClienteDto>(cliente);

                Log.Information("Cliente encontrado: {@cliente}", clienteDto);
                return Ok(clienteDto);
            }
            catch (Exception)
            {
                Log.Error("Falha em buscar o cliente com o codigo fiscal: {@cpf}", cpf);
                throw;
            }
        }

        [Authorize]
        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            try
            {
                Log.Information("Atualizando dados do cliente com ID: {@id}", id);
                var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);

                if (cliente == null)
                {
                    Log.Warning("Não encontrado cliente com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do cliente foram atualizados, dados antigos: {@cliente}", clienteDto);
                _mapper.Map(clienteDto, cliente);
               await _context.SaveChangesAsync();

                Log.Information("Dados do cliente foram atualizados, dados novos: {@cliente}", cliente);
                return NoContent();
            }
            catch (Exception)
            {
                Log.Error("Falha em atualizar os dados do cliente com ID: {@id}", id);
                throw;
            }
        }

        [Authorize]
        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                Log.Information("Deletando dados do cliente com ID: {@id}", id);
                var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);

                if (cliente == null)
                {
                    Log.Warning("Não encontrado cliente com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do cliente foram apagados, dados antigos: {@cliente}", cliente);
                _context.Clientes.Remove(cliente);
               await _context.SaveChangesAsync();

                Log.Information("Deletados com sucesso os dados do cliente com ID: {@id}", id);
                return NoContent();
            }
            catch (Exception)
            {
                Log.Error("Falha em deletar os dados do cliente com ID: {@id}", id);
                throw;
            }
        }
    }
}
