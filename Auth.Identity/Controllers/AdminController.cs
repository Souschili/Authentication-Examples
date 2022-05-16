using Auth.Identity.Data;
using Auth.Identity.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Identity.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AdminController(UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser>  signIn)
        {
            _userManager = manager;
            _signInManager = signIn;
        }

        public IActionResult Index()
        {
            return View();
        }


        // here only administrator need uncomment claim in list of claims 
        [Authorize(Roles = "Administrator")]
        public IActionResult Administrator()
        {
            return View();
        }
        // here only Manager
        [Authorize(Roles = "Manager")]
        public IActionResult Manager()
        {
            return View();
        }

        // here you can go with all claims
        [Authorize(Policy = "Multiple")]
        public IActionResult ForAll()
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

            // get user from DB
            var user =await _userManager.FindByNameAsync(viewModel.Login);

            //если пользователя нет
            if (user == null)
            {
                ModelState.AddModelError("", "User not Found");
                return View(viewModel);
            }

            var rezult=await _signInManager.PasswordSignInAsync(user.UserName,viewModel.Password,false,false);

            if (rezult.Succeeded)
            {
                // если все хорошо то редиректим 
                return Redirect(viewModel.ReturnUrl);
            }


            return View(viewModel);

            ////список клаймов
            //var claims = new List<Claim>
            //{
            //    // добавляем клайм именованый
            //    new Claim(ClaimTypes.Name,viewModel.Login),

            //    //add claim with role
            //    // with two claims user has access to all pages with Administrator and Manager claims role
            //    new Claim(ClaimTypes.Role, "Manager"),
            //    //new Claim(ClaimTypes.Role, "Administrator")
            //};

            ////обязательный параметр для аутентификации клайм айдентити
            //var claimIdentity=new ClaimsIdentity(claims,"Cookie");

            ////аутентификация через клаймы
            //ClaimsPrincipal claimPrincipal=new ClaimsPrincipal(claimIdentity);
            //await HttpContext.SignInAsync("Cookie", claimPrincipal);


           

            
        }



        public async Task<IActionResult> LogOffAsync()
        {
            //разлогин пользователя и возврат на домашнюю страницу
            //await HttpContext.SignOutAsync("Cookie");
            await _signInManager.SignOutAsync();


            return Redirect("/Home/Index");
        }
    }
}
