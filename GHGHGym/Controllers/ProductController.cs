using Microsoft.AspNetCore.Mvc;

namespace GHGHGym.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
