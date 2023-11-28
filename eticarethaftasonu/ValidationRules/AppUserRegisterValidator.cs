using eticarethaftasonu.Dto;
using FluentValidation;

namespace eticarethaftasonu.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("Adınız Giriniz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyadınızı Giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Giriniz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Emailiniz Giriniz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrarını Giriniz");
            RuleFor(x => x.FirstName).MaximumLength(30).WithMessage("En fazla 30 Karakter İsim Girebilirsiniz");
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("En az 2 karakger veri girebilirsiniz");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolanız Eşlemiyor");
        }
    }
}
