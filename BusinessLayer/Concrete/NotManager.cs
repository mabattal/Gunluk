using BusinessLayer.Abstract;
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
        EfNotRepository efNotRepository;

        public NotManager()
        {
            efNotRepository = new EfNotRepository();
        }

        public Not GetById(int id)
        {
            return efNotRepository.GetByID(id);
        }

        public List<Not> GetListAll()
        {
            return efNotRepository.GetListAll();
        }

        public void NotDelete(Not not)
        {
            efNotRepository.Delete(not);
        }

        public void NotInsert(Not not)
        {
            efNotRepository.Insert(not);
        }

        public void NotUpdate(Not not)
        {
            efNotRepository.Update(not);
        }
    }
}
