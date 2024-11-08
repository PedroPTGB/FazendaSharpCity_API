using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Data.DTOs.Funcionario;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
        private FuncionarioContext _context;
        private IMapper _mapper;

        public FuncionarioController(FuncionarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult>CreateFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);

            if(funcionario == null)
            {
                return BadRequest("Funcionadrio não pode ser nulo");
            }

            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.Id }, funcionario.Id);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult>GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if(funcionario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(funcionario);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateFuncionario(int id, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(fornecedor => fornecedor.Id == id);

            if (funcionario == null)
            {
                return NotFound();
            }

            _mapper.Map(funcionarioDto, funcionario);
            _context.SaveChanges();

            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteFuncionario(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == id);

            if(funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();

            return Ok();
        }

    }
}
