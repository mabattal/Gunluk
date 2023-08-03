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
        void YazarInsert(Not not);
        void YazarUpdate(Not not);
        void YazarDelete(Not not);
        List<Yazar> GetListAll();
        Yazar GetById(int id);
    }
}
