using Microsoft.AspNetCore.Mvc;

namespace HocicosBack.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
