using AutoMapper;
using FazendaSharpCity_API.Data.DTOs.Usuario;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FazendaSharpCity_API.Services
{   
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastra(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioDto.Password);

            if (!resultado.Succeeded) throw new ApplicationException("Falha ao cadastrar usuáio!");

        }

        public async Task<string> LoginAsync(LoginUsuarioDto loginDto)
        {
           var resultado = await _signInManager.PasswordSignInAsync(loginDto.Login, loginDto.Password, false, false);
           if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado");
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginDto.Login.ToUpper());

            var token = _tokenService.GerarToken(usuario);

            return token;

        }

    }
}
