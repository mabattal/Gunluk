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
    public class EfNotRepository : GenericRepository<Note>, INoteDal
    {
        public List<Note> GetListWithWriter()
        {
            using (var context = new Context())
            {
                return context.Notes.Include(x => x.Writer).ToList();
            }
        }
    }
}
