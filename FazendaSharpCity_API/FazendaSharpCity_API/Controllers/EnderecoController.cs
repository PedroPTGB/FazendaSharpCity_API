using Microsoft.AspNetCore.Mvc;

namespace FazendaSharpCity_API.Controllers
{
    public class EnderecoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

//Por hora não temos previsão da real necessidade de um controler para endereco
