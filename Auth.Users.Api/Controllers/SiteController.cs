using IdentityModel.Client;
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
            //retrive Identity4Server
            var auth_client=_httpClientFactory.CreateClient();
            var discovery = await auth_client.GetDiscoveryDocumentAsync("https://localhost:8001");

            // retrive orders 
            var client=_httpClientFactory.CreateClient();

            var responce =await  client.GetAsync("https://localhost:5001/site/secret");
            
            var message= await responce.Content.ReadAsStringAsync();
            ViewBag.message = message;
            return View();
        }
    }
}
