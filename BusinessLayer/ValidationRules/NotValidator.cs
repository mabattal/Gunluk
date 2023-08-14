using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NotValidator : AbstractValidator<Not>
    {
        public NotValidator() 
        {
            RuleFor(x => x.Konu).NotEmpty().WithMessage("Başlık kısmı boş geçilemez")
                .MaximumLength(50).WithMessage("Başlık en fazla 50 karekter içermelidir");
            RuleFor(x => x.Metin).NotEmpty().WithMessage("İçerik kısmı boş geçilemez")
                .MaximumLength(2000).WithMessage("İçerik en fazla 2000 karekter içermelidir");
        }
    }
}
