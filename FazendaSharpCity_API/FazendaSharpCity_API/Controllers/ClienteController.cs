using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace FazendaSharpCity_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private ApiContext _context;
        private IMapper _mapper;

        public ClienteController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult adicionaCliente([FromBody] CreateClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(lerCLientePorId), new { id = cliente.Id }, cliente);
        }

        [HttpGet]
        public IEnumerable<ReadClienteDto> lerCliente([FromQuery] int pageNumber = 1, int pageQtd = 10, string? nome = null)
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

        [HttpGet("{id}")]
        public IActionResult lerCLientePorId(int id) 
        {
            var cliente =  _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();
            var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
            return Ok(clienteDto);
        }

        [HttpPut("{id}")]
        public IActionResult atualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();
            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deletaCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
