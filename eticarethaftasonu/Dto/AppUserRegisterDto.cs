using System.ComponentModel.DataAnnotations;

namespace eticarethaftasonu.Dto
{
    public class AppUserRegisterDto
    {
        //[Required(ErrorMessage ="Adınız Boş Bıraktınız")]
        [Display(Name ="Adınızı Girin")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Soyadınızı Boş Bıraktınız")]
        [Display(Name = "Soyadınızı Girin")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Kullanıcı Boş Bıraktınız")]
        [Display(Name = "Kullanıcı Adınızı Girin")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Email Boş Bıraktınız")]
        [Display(Name = "Email Adresinizi Girin")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
