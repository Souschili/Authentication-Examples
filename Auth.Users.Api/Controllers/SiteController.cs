using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth.Users.Api.Controllers
{
    public class SiteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SiteController(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetOrders()
        {
            var client=_httpClientFactory.CreateClient();

            var responce =await  client.GetAsync("https://localhost:5001/site/secret");
            
            var message= await responce.Content.ReadAsStringAsync();
            ViewBag.message = message;
            return View();
        }
    }
}
