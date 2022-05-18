using Microsoft.AspNetCore.Mvc;

namespace Auth.Users.Api.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
