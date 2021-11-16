using BlogYeniden.Models;
using BlogYeniden.Models.Data;
using BlogYeniden.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogYeniden.Controllers
{
    public class AuthController : Controller
    {
        private readonly UygulamaDbContext _db;

        public AuthController(UygulamaDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
               if( _db.Users.Any(x => x.Username == loginView.Username && x.Password == loginView.Password))
               {
                    TempData["LoginSuccess"] = "Giriş Başarılı";
                    return RedirectToAction("Index", "Home");
               }
                ModelState.AddModelError("","Kullanıcı adı veya şifre hatalı");
                return View(loginView);
            }
            ModelState.AddModelError("", "Adam akıllı yaz la!");
            return View();
        }

        public IActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                if (!_db.Users.Any(x => x.Username == registerModel.Username))
                {
                    _db.Users.Add(new User(registerModel.Username, registerModel.Password));
                    _db.SaveChanges();
                    TempData["RegisterSuccess"] = "Kayıt İşlemi Başarılı";
                    return RedirectToAction("Login", "Auth");
                }
                ModelState.AddModelError("", "Kullanıcı adı zaten alınmış");
                return View(registerModel);
            }
            ModelState.AddModelError("", "Adam akıllı yaz la!");
            return View();
        }
    }
}
