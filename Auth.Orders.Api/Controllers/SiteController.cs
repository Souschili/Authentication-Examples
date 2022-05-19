using Microsoft.AspNetCore.Mvc;

namespace Auth.Orders.Api.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string GetSecret()=>
            "Get secret from Order Api";
    }
}
