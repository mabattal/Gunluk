using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IYazarDal : IGenericDal<Yazar>
    {
        Yazar GetByLogin(string mail, string sifre);
    }
}
