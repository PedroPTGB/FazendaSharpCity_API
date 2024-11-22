
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FazendaSharpCity_API.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;
        private UserManager<Usuario> _userManager;

        public TokenService(IConfiguration configuration, UserManager<Usuario> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }


        public async Task<string> GerarToken(Usuario usuario)
        {
            var userRoles = await _userManager.GetRolesAsync(usuario);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim("id", usuario.Id)//,
                //new Claim("NivelGerencial", usuario.NivelGerencial.ToString())
            };

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}