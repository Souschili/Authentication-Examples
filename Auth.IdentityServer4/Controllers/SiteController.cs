using Microsoft.AspNetCore.Mvc;

namespace Auth.IdentityServer4.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
