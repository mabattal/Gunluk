using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Yazar
    {
        [Key]
        public int YazarId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Mail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sifre { get; set; }
        public bool YazarSil { get; set; } = false;

        public List<Not> Nots { get; set; }
    }
}
