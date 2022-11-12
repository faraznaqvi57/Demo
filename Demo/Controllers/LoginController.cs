using Demo.Entity;
using Demo.Models;
using Demo.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class LoginController : Controller
    {
        private readonly CarDetailsDbContext _context;
        private readonly IrepoLogin _lrepo;

        public LoginController(CarDetailsDbContext context,IrepoLogin lrepo) 
        {
            _context = context;
            _lrepo=lrepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string emailId, string password)
        {
            var listOfLogin=_context.logins.ToList();

            foreach (var login in listOfLogin)
            {
                if (login.emailId == emailId)
                {
                    if (login.password == password)
                    {
                        return RedirectToAction("Index", "CarDetails");
                    }
                    else
                    {
                        return View("loginError");
                    }
                }
            }

            return View("loginError");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(login login)
        {
            if(ModelState.IsValid)
            {
                _lrepo.registration(login);
                return RedirectToAction("Index");
            }
            return View();
            
        }
    }
}
