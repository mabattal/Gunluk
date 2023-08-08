using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INotService : IGenericService<Not>
    {
        List<Not> GetNotListWithYazar();
        List<Not> GetNotListByYazar(int id);
    }
}
