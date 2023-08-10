using Microsoft.EntityFrameworkCore;

namespace ApiLayer.DataAccessLayer
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-73I52K7; database=CoreGunlukApi; integrated security=True; TrustServerCertificate=True;");
        }

        public DbSet<Calisan> Calisans { get; set; }
    }
}
