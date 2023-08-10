using System.ComponentModel.DataAnnotations;

namespace ApiLayer.DataAccessLayer
{
    public class Calisan
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
    }
}
