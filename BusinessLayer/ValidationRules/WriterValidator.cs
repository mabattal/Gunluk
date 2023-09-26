using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad kısmı boş geçilemez")
                .MinimumLength(2).WithMessage("Adınız en az 2 karekter olmalıdır")
                .MaximumLength(50).WithMessage("Adınız en fazla 50 karekter içermelidir");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad kısmı boş geçilemez")
                .MinimumLength(2).WithMessage("Soyadınız en az 2 karekter olmalıdır")
                .MaximumLength(50).WithMessage("Soyadınız en fazla 50 karekter içermelidir");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail kısmı boş geçilemez")
                .EmailAddress().WithMessage("Mail adresi doğru formatta olmalıdır");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre kısmı boş geçilemez")
                .MinimumLength(3).WithMessage("Şifreniz en az 3 karakter olmalıdır");
        }

      
    }
}
