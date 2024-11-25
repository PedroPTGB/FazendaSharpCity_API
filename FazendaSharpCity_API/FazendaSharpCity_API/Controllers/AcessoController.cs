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
        //[Authorize(Policy = "NivelGerencial")]
        [Authorize(Roles = UserRoles.Admin)]
        //[Authorize]
        public IActionResult Get()
        {
            return Ok("Acesso Permitido");
        }

        [HttpGet("AcessoAdmin")]
        //[Authorize(Policy = "NivelGerencial")]
        [Authorize(Roles = UserRoles.Admin)]
        //[Authorize]
        public IActionResult Getadmin()
        {
            return Ok("Acesso Permitido");
        }
    }
}
