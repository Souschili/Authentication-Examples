using Microsoft.AspNetCore.Mvc;

namespace Auth.Orders.Api.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Secret()=>
            "Get secret from Order Api";
    }
}
