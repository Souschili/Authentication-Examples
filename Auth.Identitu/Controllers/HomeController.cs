﻿using Microsoft.AspNetCore.Mvc;

namespace Auth.Basic.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult AccessDenide()
        {
            return View();
        }

        public IActionResult Index()
        {
            ViewBag.Name = User.Identity.Name;
            ViewBag.Auth = User.Identity.IsAuthenticated;
            return View();
        }
    }
}
