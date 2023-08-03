using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotManager : INotService
    {
        public Not GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Not> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void NotDelete(Not not)
        {
            throw new NotImplementedException();
        }

        public void NotInsert(Not not)
        {
            throw new NotImplementedException();
        }
    }
}
