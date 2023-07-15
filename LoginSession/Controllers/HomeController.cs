using LoginSession.Extensions;
using LoginSession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!IsLogged()) return RedirectToAction("Login", "Login");
            return View();
        }

        public IActionResult Privacy()
        {
            if (!IsLogged()) return RedirectToAction("Login", "Login");
            return View();
        }

        private bool IsLogged()
        {
            User loggedUser = HttpContext.Session.GetObject<User>("user");
            if(loggedUser == null) return false;
            return true;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
