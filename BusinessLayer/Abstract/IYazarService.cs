using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IYazarService
    {
        void YazarInsert(Yazar yazar);
        void YazarUpdate(Yazar yazar);
        void YazarDelete(Yazar yazar);
        List<Yazar> GetListAll();
        Yazar GetById(int id);
    }
}
