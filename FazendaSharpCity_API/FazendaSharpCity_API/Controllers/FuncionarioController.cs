using AutoMapper;
using FazendaSharpCity_API.Authorization;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Cliente;
using FazendaSharpCity_API.Data.DTOs.Funcionario;
using FazendaSharpCity_API.Models;
using FazendaSharpCity_API.Services;
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
        private ApiService _apiService;

        public FuncionarioController(ApiContext context, IMapper mapper, ApiService apiService)
        {
            _context = context;
            _mapper = mapper;
            _apiService = apiService;
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CreateFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            try
            {
                Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);

                bool funcionarioUnico = await _apiService.VerificaUnicoFuncionario(funcionario);
                if (funcionarioUnico)
                {
                    await _context.Funcionarios.AddAsync(funcionario);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.Id }, funcionario);
                }

                return BadRequest("CPF cadastrado para outro funcionario");


            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("PesquisaId/{id}")]
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


        [Authorize]
        [HttpGet]
        public IEnumerable<ReadFuncionarioDto> ReadFuncionario([FromQuery] int pageNumber = 1, int pageQtd = 10, string? nome = null)
        {
            try
            {

                List<ReadFuncionarioDto> funcionarios = new List<ReadFuncionarioDto>();
                for (int i = pageNumber - 1; i < pageQtd; i++)
                {

                    if (nome == null)
                    {
                        var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == i);
                        if (funcionario != null)
                        {
                            var funcionarioDto = _mapper.Map<ReadFuncionarioDto>(funcionario);
                            funcionarios.Add(funcionarioDto);
                        }
                    }
                    else
                    {
                        var funcionario = _context.Funcionarios.Where(funcionario => funcionario.Nome.Contains(nome));
                        if (funcionario != null)
                        {
                            var funcionarioDto = _mapper.Map<ReadFuncionarioDto>(funcionario);
                            funcionarios.Add(funcionarioDto);
                        }
                    }
                }

                return funcionarios;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Authorize]
        [HttpGet("PesquisaCPF/{cpf}")]
        public async Task<IActionResult> ReadFuncionarioCPF(string cpf)
        {
            try
            {
                Funcionario funcionario = null;

                funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.CPF == cpf);

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
        [HttpPut("Atualizar/{id}")]
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
