using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık kısmı boş geçilemez")
                .MaximumLength(50).WithMessage("Başlık en fazla 50 karekter içermelidir");
            RuleFor(x => x.Text).NotEmpty().WithMessage("İçerik kısmı boş geçilemez")
                .MaximumLength(2000).WithMessage("İçerik en fazla 2000 karekter içermelidir");
        }
    }
}
