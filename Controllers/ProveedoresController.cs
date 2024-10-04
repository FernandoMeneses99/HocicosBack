using Microsoft.AspNetCore.Mvc;

namespace HocicosBack.Controllers
{
    public class ProveedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
