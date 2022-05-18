using Microsoft.AspNetCore.Mvc;

namespace Auth.Orders.Api.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
