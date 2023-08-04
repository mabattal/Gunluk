using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INotService
    {
        void NotInsert(Not not);
        void NotUpdate(Not not);
        void NotDelete(Not not);
        List<Not> GetListAll();
        Not GetById(int id);
        List<Not> GetNotListWithYazar();
    }
}
