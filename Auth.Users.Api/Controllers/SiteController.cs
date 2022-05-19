using Microsoft.AspNetCore.Mvc;

namespace Auth.Users.Api.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrders()
        {
            ViewBag.message = "Test Data";
            return View();
        }
    }
}
