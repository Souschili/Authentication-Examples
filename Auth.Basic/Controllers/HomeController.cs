using Microsoft.AspNetCore.Mvc;

namespace Auth.Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
