using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CreateNotDto
    {
        public int Id { get; set; }

        public string? Konu { get; set; }

        public string? Metin { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public bool NotSil { get; set; } = false;

        public int YazarId { get; set; }
    }
}
