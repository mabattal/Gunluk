using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfNotRepository : GenericRepository<Not>, INotDal
    {
        public List<Not> GetListWithYazar()
        {
            using (var context = new Context())
            {
                return context.Nots.Include(x => x.Yazar).ToList();
            }
        }
    }
}
