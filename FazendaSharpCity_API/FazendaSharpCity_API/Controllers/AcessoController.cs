using FazendaSharpCity_API.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FazendaSharpCity_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Acesso Permitido");
        }

        [HttpGet("AcessoAdmin")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Getadmin()
        {
            return Ok("Acesso Permitido");
        }
    }
}
