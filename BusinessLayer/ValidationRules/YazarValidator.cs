using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class YazarValidator : AbstractValidator<Yazar>
    {
        public YazarValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad kısmı boş geçilemez")
                .MinimumLength(2).WithMessage("Adınız en az 2 karekter olmalıdır")
                .MaximumLength(50).WithMessage("Adınız en fazla 50 karekter içermelidir");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyad kısmı boş geçilemez")
                .MinimumLength(2).WithMessage("Soyadınız en az 2 karekter olmalıdır")
                .MaximumLength(50).WithMessage("Soyadınız en fazla 50 karekter içermelidir");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail kısmı boş geçilemez");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre kısmı boş geçilemez")
                .MinimumLength(3).WithMessage("Şifreniz en az 3 karakter olmalıdır");
        }

      
    }
}
