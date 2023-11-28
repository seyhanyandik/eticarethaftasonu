using eticarethaftasonu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eticarethaftasonu.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<AppUser> _singInManager;

        public LogoutController(SignInManager<AppUser> singInManager)
        {
            _singInManager = singInManager;
        }

        public async Task <IActionResult> Index()
        {
            await _singInManager.SignOutAsync();
            ViewBag.Mesaj = "Sistem Çıkışınız Sağlandı";
            return View();
        }
    }
}
