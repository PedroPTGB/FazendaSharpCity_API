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
        [HttpPost]
        public async Task<IActionResult> CreateClienteDto([FromBody] CreateClienteDto clienteDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);

                bool clienteUnico = await _apiService.VerificaUnicoCliente(cliente);
                if (clienteUnico)
                {
                    await _context.Clientes.AddAsync(cliente);
                    await _context.SaveChangesAsync();
                    
                    return CreatedAtAction(nameof(ReadClienteId), new { id = cliente.Id }, cliente);
                }

                return BadRequest("CPF ou CNPJ cadastrado para outro cliente");
                    
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ReadClienteDto> ReadCliente([FromQuery] int pageNumber = 1, int pageQtd = 10, string? nome = null)
        {
            try
            {

                //var listaClientes = _mapper.Map<IEnumerable<ReadClienteDto>>(_context.Clientes.Skip((pageNumber - 1) * pageQtd).Take(pageQtd));
                List<ReadClienteDto> clientes = new List<ReadClienteDto>();
                for (int i = pageNumber - 1; i < pageQtd; i++)
                {

                    if (nome == null)
                    {
                        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == i);
                        if (cliente != null)
                        {
                            var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
                            clientes.Add(clienteDto);
                        }
                    }
                    else
                    {
                        var cliente = _context.Clientes.Where(cliente => cliente.Nome.Contains(nome));
                        if (cliente != null)
                        {
                            var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
                            clientes.Add(clienteDto);
                        }
                    }
                }

                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> ReadClienteId(int id) 
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);

                if (cliente == null)
                {
                    return NotFound();
                }

                var clienteDto = _mapper.Map<ReadClienteDto>(cliente);

                return Ok(clienteDto);
            }
            catch (Exception)
            {
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
                    cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.CPF == cpf);
                }
                else if(cpf.Length == 13)
                {
                    cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.CNPJ == cpf);
                }

                if (cliente == null)
                {
                    return NotFound();
                }

                var clienteDto = _mapper.Map<ReadClienteDto>(cliente);

                return Ok(clienteDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);

                if (cliente == null)
                {
                    return NotFound();
                } 

                _mapper.Map(clienteDto, cliente);
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
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);

                if (cliente == null)
                {
                    return NotFound();
                } 

                _context.Clientes.Remove(cliente);
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
