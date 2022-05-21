using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Orders.Api.Controllers
{
    [Route("[controller]")]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        [Authorize]
        public string Secret()=>
            "Get secret from Order Api !!!!";
    }
}
