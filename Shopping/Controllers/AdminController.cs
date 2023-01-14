using Microsoft.AspNetCore.Mvc;

namespace Shopping.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
