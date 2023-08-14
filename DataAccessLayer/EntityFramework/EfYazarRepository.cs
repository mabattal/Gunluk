using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfYazarRepository : GenericRepository<Yazar>, IYazarDal
    {
        Context context = new Context();
        public Yazar GetByLogin(string mail, string sifre)
        {
            return context.Yazars.FirstOrDefault(x => x.YazarSil == false && x.Mail == mail && x.Sifre == sifre);
        }
    }
}
