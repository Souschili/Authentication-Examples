using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Basic.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            //при переходе, получаем параметр из строки адресса и потом используем его в пост запросе
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //возращаем модель на страницк запроса
                return View(viewModel);
            }

            //список клаймов
            var claims = new List<Claim>
            {
                // добавляем клайм именованый
                new Claim(ClaimTypes.Name,viewModel.Login)
            };

            //обязательный параметр для аутентификации клайм айдентити
            var claimIdentity=new ClaimsIdentity(claims,"Cookie");

            //аутентификация через клаймы
            ClaimsPrincipal claimPrincipal=new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            // если все хорошо то редиректим 
            return Redirect(viewModel.ReturnUrl);
        }



        public async Task<IActionResult> LogOffAsync()
        {
            //разлогин пользователя и возврат на домашнюю страницу
            await HttpContext.SignOutAsync("Cookie");


            return Redirect("/Home/Index");
        }
    }
}
