using AutoMapper;
using FazendaSharpCity_API.Authorization;
using FazendaSharpCity_API.Data.DTOs.Usuario;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FazendaSharpCity_API.Services
{   
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;
        private RoleManager<IdentityRole> _roleManager;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        public async Task Cadastra(CreateUsuarioDto usuarioDto)
        {
            Log.Information("Cadastrando usuáio");
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioDto.Password);

            if (!resultado.Succeeded) 
            {
                Log.Error("Falha ao cadastrar usuáio");
                throw new ApplicationException("Falha ao cadastrar usuáio!"); 
            }

        }

        public async Task CadastraAdmin(CreateUsuarioDto usuarioDto)
        {
            Log.Information("Cadastrando usuáio admin");
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioDto.Password);

            if (!resultado.Succeeded)
            {
                Log.Error("Falha ao cadastrar usuáio admin");
                throw new ApplicationException("Falha ao cadastrar usuáio!");
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _userManager.AddToRoleAsync(usuario, UserRoles.Admin);
        }

        public async Task<string> LoginAsync(LoginUsuarioDto loginDto)
        {
           var resultado = await _signInManager.PasswordSignInAsync(loginDto.Login, loginDto.Password, false, false);
           if (!resultado.Succeeded)
            {
                Log.Error("Falha ao autenticar o usuáio");
                throw new ApplicationException("Usuário não autenticado");
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginDto.Login.ToUpper());

            var token = _tokenService.GerarToken(usuario);

            return await token;

        }

    }
}
