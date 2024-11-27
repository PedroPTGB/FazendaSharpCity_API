using AutoMapper;
using FazendaSharpCity_API.Authorization;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Usuario;
using FazendaSharpCity_API.Models;
using FazendaSharpCity_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("CadastroFunci")]
        public async Task<IActionResult> CadatraUsuario(CreateUsuarioDto usuarioDto)
        {
            Log.Information("Cadastrando o usuario do funcionario");
            await _usuarioService.Cadastra(usuarioDto);

            Log.Information("Usuario do funcionario cadastrado com sucesso");
            return Ok("Usuário cadastrado!");
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("CadastroAdmin")]
        public async Task<IActionResult> CadatraAmin(CreateUsuarioDto usuarioDto)
        {
            Log.Information("Cadastrando o usuario do administrador");
            await _usuarioService.CadastraAdmin(usuarioDto);

            Log.Information("Usuario do administrador cadastrado com sucesso");
            return Ok("Usuário cadastrado!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto loginDto)
        {
            Log.Information("Realizando login");
            var token = await _usuarioService.LoginAsync(loginDto);

            Log.Information("Login realzado com sucesso");
            return Ok(token);
        }
    }
}
