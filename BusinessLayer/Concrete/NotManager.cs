using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
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
        INotDal _notDal;

        public NotManager(INotDal notDal)
        {
            _notDal = notDal;
        }

        public Not GetById(int id)
        {
            return _notDal.GetByID(id);
        }

        public List<Not> GetListAll()
        {
            return _notDal.GetListAll();
        }

        public void NotDelete(Not not)
        {
            _notDal.Delete(not);
        }

        public void NotInsert(Not not)
        {
            _notDal.Insert(not);
        }

        public void NotUpdate(Not not)
        {
            _notDal.Update(not);
        }
    }
}
