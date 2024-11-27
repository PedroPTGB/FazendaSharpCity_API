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
using Serilog;

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
                Log.Information("Cadastrando funcionario");
                Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);

                bool funcionarioUnico = await _apiService.VerificaUnicoFuncionario(funcionario);
                if (funcionarioUnico)
                {
                    await _context.Funcionarios.AddAsync(funcionario);
                    await _context.SaveChangesAsync();

                    Log.Information("Dados cadastrados do funcionario: {@funcionario}", funcionario);
                    return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.Id }, funcionario);
                }

                Log.Warning("CPF informado para o funcionario já existe no banco de dados");
                return BadRequest("CPF cadastrado para outro funcionario");


            }
            catch (Exception)
            {
                Log.Error("Falha em criar o funcionario: {@funcionarioDto}", funcionarioDto);
                throw;
            }
        }
        
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("PesquisaId/{id}")]
        public async Task<IActionResult> GetFuncionario(int id)
        {
            try
            {
                Log.Information("Buscando funcionario pelo ID: {@id}", id);
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.Id == id);

                if (funcionario == null)
                {
                    Log.Warning("Não encontrado funcionario com ID: {@id}", id);
                    return NotFound();
                }

                var funcionarioDto = _mapper.Map<ReadFuncionarioDto>(funcionario);

                Log.Information("Funcionario encontrado: {@funcionarioDto}", funcionarioDto);
                return Ok(funcionarioDto);

            }
            catch (Exception)
            {
                Log.Error("Falha em buscar o funcionario pelo ID: {@id}", id);
                throw;
            }
        }


        [Authorize]
        [HttpGet]
        public IEnumerable<ReadFuncionarioDto> ReadFuncionario([FromQuery] int pageNumber = 1, int pageQtd = 10)
        {
            try
            {
                Log.Information("Listando funcionarios do banco de dados, pagina {@pageNumber} com {@pageQtd} elementos por pagina", pageNumber, pageQtd);

                List<ReadFuncionarioDto> funcionarios = new List<ReadFuncionarioDto>();
                for (int i = (pageNumber - 1) * pageQtd; i < ((pageNumber - 1) * pageQtd) + pageQtd; i++)
                {
                    var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == i);
                    if (funcionario != null)
                    {
                        var funcionarioDto = _mapper.Map<ReadFuncionarioDto>(funcionario);
                        funcionarios.Add(funcionarioDto);
                    }
                }

                return funcionarios;
            }
            catch (Exception)
            {
                Log.Error("Falha em listar os funcionarios");
                throw;
            }
        }


        [Authorize]
        [HttpGet("PesquisaCPF/{cpf}")]
        public async Task<IActionResult> ReadFuncionarioCPF(string cpf)
        {
            try
            {
                Log.Information("Buscando funcionario pelo CPF: {@cpf}", cpf);
                Funcionario funcionario = null;

                funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.CPF == cpf);

                if (funcionario == null)
                {
                    Log.Warning("Não encontrado funcionario com o CPF: {@cpf}", cpf);
                    return NotFound();
                }

                var funcionarioDto = _mapper.Map<ReadFuncionarioDto>(funcionario);

                Log.Information("Funcionario encontrado: {@funcionarioDto}", funcionarioDto);
                return Ok(funcionarioDto);
            }
            catch (Exception)
            {
                Log.Error("Falha em buscar o funcionario com o codigo fiscal: {@cpf}", cpf);
                throw;
            }
        }



        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> UpdateFuncionario(int id, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            try
            {
                Log.Information("Atualizando dados do funcionario com ID: {@id}", id);
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);

                if (funcionario == null)
                {
                    Log.Warning("Não encontrado funcionario com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do funcionario foram atualizados, dados antigos: {@funcionarioDto}", funcionarioDto);
                _mapper.Map(funcionarioDto, funcionario);
                await _context.SaveChangesAsync();

                Log.Information("Dados do funcionario foram atualizados, dados novos: {@funcionario}", funcionario);
                return NoContent();
            }
            catch (Exception)
            {
                Log.Error("Falha em atualizar os dados do funcionario com ID: {@id}", id);
                throw;
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("Atualizar/CPF/{cpf}")]
        public async Task<IActionResult> UpdateFuncionarioCPF(string cpf, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            try
            {
                Log.Information("Atualizando dados do funcionario com CPF: {@cpf}", cpf);
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(fornecedor => fornecedor.CPF == cpf);

                if (funcionario == null)
                {
                    Log.Warning("Não encontrado funcionario com CPF: {@id}", cpf);
                    return NotFound();
                }

                Log.Information("Dados do funcionario foram atualizados, dados antigos: {@funcionarioDto}", funcionarioDto);
                _mapper.Map(funcionarioDto, funcionario);
                await _context.SaveChangesAsync();

                Log.Information("Dados do funcionario foram atualizados, dados novos: {@funcionario}", funcionario);
                return NoContent();
            }
            catch (Exception)
            {
                Log.Error("Falha em atualizar os dados do funcionario com CPF: {@cpf}", cpf);
                throw;
            }
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> DeletarFuncionario(int id)
        {
            try
            {
                Log.Information("Deletando dados do funcionario com ID: {@id}", id);
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.Id == id);

                if (funcionario == null)
                {
                    Log.Warning("Não encontrado funcionario com ID: {@id}", id);
                    return NotFound();
                }

                Log.Information("Dados do funcionario foram apagados, dados antigos: {@funcionario}", funcionario);
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                Log.Information("Deletados com sucesso os dados do funcionario com ID: {@id}", id);
                return Ok();
            }
            catch (Exception)
            {
                Log.Error("Falha em deletar os dados do funcionario com ID: {@id}", id);
                throw;
            }
        }

    }
}
