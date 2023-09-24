using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class YazarManager : IYazarService
    {
        IYazarDal _yazarDal;

        public YazarManager(IYazarDal yazarDal)
        {
            _yazarDal = yazarDal;
        }
        public Yazar GetById(int id)
        {
            return _yazarDal.GetByID(id);
        }

        public List<Yazar> GetListAll()
        {
            return _yazarDal.GetListAll();
        }

        public void Delete(Yazar yazar)
        {
            _yazarDal.Delete(yazar);
        }

        public void Insert(Yazar yazar)
        {
            _yazarDal.Insert(yazar);
        }

        public void Update(Yazar yazar)
        {
            _yazarDal.Update(yazar);
        }

        public Yazar GetByLogin(string mail)
        {
            return _yazarDal.GetByLogin(mail);
        }
    }
}
