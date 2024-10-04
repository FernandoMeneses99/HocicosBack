using Microsoft.AspNetCore.Mvc;

namespace HocicosBack.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
