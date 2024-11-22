using AutoMapper;
using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Data.DTOs.Usuario;
using FazendaSharpCity_API.Models;
using FazendaSharpCity_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadatraUsuario(CreateUsuarioDto usuarioDto)
        {
            await _usuarioService.Cadastra(usuarioDto);
            return Ok("Usuário cadastrado!");
        }

        [HttpPost("CadastroAdmin")]
        public async Task<IActionResult> CadatraAmin(CreateUsuarioDto usuarioDto)
        {
            await _usuarioService.CadastraAdmin(usuarioDto);
            return Ok("Usuário cadastrado!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto loginDto)
        {
            var token = await _usuarioService.LoginAsync(loginDto);
            return Ok(token);
        }
    }
}
