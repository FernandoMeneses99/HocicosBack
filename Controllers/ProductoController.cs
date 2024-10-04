using Microsoft.AspNetCore.Mvc;

namespace HocicosBack.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
