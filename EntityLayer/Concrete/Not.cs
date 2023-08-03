using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Not
    {
        [Key]
        public int Id { get; set; }
        public string Konu { get; set; }
        public string Metin { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public bool NotSil { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Konu))
                yield return new ValidationResult("Konu boş olamaz.", new[] { nameof(Konu) });

            if (string.IsNullOrEmpty(Metin))
                yield return new ValidationResult("Metin boş olamaz.", new[] { nameof(Metin) });
        }
    }






}
