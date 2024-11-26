using AutoMapper;
using FazendaSharpCity_API.Authorization;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Data.DTOs.Funcionario;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
        private ApiContext _context;
        private IMapper _mapper;

        public FuncionarioController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            try
            {
                Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);

                if (funcionario == null)
                {
                    return BadRequest("Funcionadrio não pode ser nulo");
                }

                await _context.Funcionarios.AddAsync(funcionario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.Id }, funcionario.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionario(int id)
        {
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.Id == id);

                if (funcionario == null)
                {
                    return NotFound();
                }

                var funcionarioDto = _mapper.Map<ReadFuncionarioDto>(funcionario);
                return Ok(funcionarioDto);

            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuncionario(int id, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (funcionario == null)
                {
                    return NotFound();
                }

                _mapper.Map(funcionarioDto, funcionario);
                await _context.SaveChangesAsync();

                return Ok(funcionario);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFuncionario(int id)
        {
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.Id == id);

                if (funcionario == null)
                {
                    return NotFound();
                }

                _context.Funcionarios.Remove(funcionario);
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
