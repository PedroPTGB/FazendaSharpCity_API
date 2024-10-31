﻿using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FazendaSharpCity_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private ClienteContext _context;
        private IMapper _mapper;

        public ClienteController(ClienteContext context, IMapper mapper)
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
        public IEnumerable<ReadClienteDto> lerCliente([FromQuery] int pageNumber = 1, int pageQtd = 10)
        {
            return _mapper.Map<IEnumerable<ReadClienteDto>>(_context.Clientes.Skip((pageNumber-1)*pageQtd).Take(pageQtd));
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

        [HttpPatch("{id}")]
        public IActionResult atualizaClienteParcial(int id, JsonPatchDocument<UpdateClienteDto> patch)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();

            var clienteParcial = _mapper.Map<UpdateClienteDto>(cliente);
            patch.ApplyTo(clienteParcial, ModelState);

            if (!TryValidateModel(clienteParcial))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(clienteParcial, cliente);
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