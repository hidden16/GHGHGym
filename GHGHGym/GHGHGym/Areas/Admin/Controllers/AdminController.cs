using Microsoft.AspNetCore.Mvc;

namespace GHGHGym.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
