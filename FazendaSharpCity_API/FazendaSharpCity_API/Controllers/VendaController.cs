using Microsoft.AspNetCore.Mvc;

namespace FazendaSharpCity_API.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
