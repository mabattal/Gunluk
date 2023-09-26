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
    public class YazarManager : IWriterService
    {
        IWriterDal _yazarDal;

        public YazarManager(IWriterDal yazarDal)
        {
            _yazarDal = yazarDal;
        }
        public Writer GetById(int id)
        {
            return _yazarDal.GetByID(id);
        }

        public List<Writer> GetListAll()
        {
            return _yazarDal.GetListAll();
        }

        public void Delete(Writer writer)
        {
            _yazarDal.Delete(writer);
        }

        public void Insert(Writer writer)
        {
            _yazarDal.Insert(writer);
        }

        public void Update(Writer writer)
        {
            _yazarDal.Update(writer);
        }

        public Writer GetByLogin(string mail)
        {
            return _yazarDal.GetByLogin(mail);
        }
    }
}
