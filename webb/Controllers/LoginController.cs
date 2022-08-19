using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using webb.Models;


namespace webb.Controllers
{
    public class LoginController : Controller
    {
        
        private SqlContext context;
        public LoginController(SqlContext sqlContext)
        {
            context = sqlContext;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Login(Login login)
        {
            if (login != null && login.KullaniciAdi != null)
            {
                Login Login = context.Logins.Where(x => x.KullaniciAdi == login.KullaniciAdi && x.Sifre == login.Sifre).FirstOrDefault();
                if (Login != null)
                {
                    return View("../Home/Index");
                }
            }
            return View();

        }

        public ViewResult Entry(Login login)
        {
            if (login != null && login.KullaniciAdi != null)
            {
                context.Logins.Add(login);
                context.SaveChanges();
                return View("Login");
            }
            else
            {
                return View();
            }
            
            





        }
    }
}
