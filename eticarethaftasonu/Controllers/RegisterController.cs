using eticarethaftasonu.Dto;
using eticarethaftasonu.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;



namespace eticarethaftasonu.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
           Random random = new Random();
            int code = 0;
            code = random.Next(100000, 1000000);
            AppUser appUser = new AppUser()
            {
                FirstName = appUserRegisterDto.FirstName,
                LastName = appUserRegisterDto.LastName,
                UserName = appUserRegisterDto.UserName,

                Email = appUserRegisterDto.Email,
                City = "İstanbul",
                ConfirmCode = code,

            };
            var result =await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
            if(result.Succeeded)
            {
                MimeMessage mimeMessage= new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Hafta Sonu Grubu", "muratciplak917@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Kayıt İşleminiz Gerçekleştirmek için Onay Kodunu Giriniz" + code;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Arı Bilgi Hafta Grubu ";

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("muratciplak917@gmail.com","ayvs pnsr jumg cdqa");
                client.Send(mimeMessage);
                client.Disconnect(true);
                TempData["Mail"] = appUserRegisterDto.Email;

                return RedirectToAction("Index","ConfirmMail");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
           

        }
    }
}
