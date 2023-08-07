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

        public List<Not> GetNotById(int id)
        {
            return _notDal.GetListAll(x => x.Id == id);
        }

        public List<Not> GetNotListWithYazar()
        {
            return _notDal.GetListWithYazar();
        }

        public void TDelete(Not not)
        {
            _notDal.Delete(not);
        }

        public void TInsert(Not not)
        {
            _notDal.Insert(not);
        }

        public void TUpdate(Not not)
        {
            _notDal.Update(not);
        }
    }
}
