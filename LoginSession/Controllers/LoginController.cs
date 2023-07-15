using LoginSession.Extensions;
using LoginSession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginSession.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            User loggedUser = HttpContext.Session.GetObject<User>("user");

            if(loggedUser == null) return View();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObject("user", user);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Exit()
        {
            HttpContext.Session.Clear();
            //HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
            
        }
        // Eğer kontrol kaçanılmaz ise ve her iki olasılık durumdada aynı miktarda işlem yapılacaksa
        // Böyle bir senaryoda her zaman ilk koşul olumlu olmalı.
        // İf else mantığında if eğer şöyleyse şeklinde özetlenirken else değilse şeklinde negatifi temsil etmeli.
        // Bundan dolayı if genelte true, else ise false olan terimleri içermelidir.

        //ama projemizde birden fazla kod aşaması ve bu aşamaları çıktılarının tutuarlılığı önemli ise, ilk nbbaşta 3 saniyelik bir kontrol yapmak ve sonraki satırlar yaşanabilecek olası data tutarlılığı temelli hatalarda harcanak 15 saniyeyi önlüyorsa böyle durumlarda ilk önce verinin tutarlılığı veya istenilen şekilde olup olmadığı kontrol edilmelir.


    }
}
