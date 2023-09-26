using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfYazarRepository : GenericRepository<Writer>, IWriterDal
    {
        Context context = new Context();
        public Writer GetByLogin(string mail)
        {
            return context.Writers.FirstOrDefault(x=>x.Mail == mail);
        }
    }
}
