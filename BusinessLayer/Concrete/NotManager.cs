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
    public class NotManager : INoteService
    {
        INoteDal _notDal;

        public NotManager(INoteDal notDal)
        {
            _notDal = notDal;
        }

        public Note GetById(int id)
        {
            return _notDal.GetByID(id);
        }

        public List<Note> GetListAll()
        {
            return _notDal.GetListAll();
        }

        public Note GetNoteById(int id)
        {
            return _notDal.GetByID(id);
        }

        public List<Note> GetNoteListByWriter(int id)
        {
            return _notDal.GetListAll(x =>x.WriterId == id).Where(not => not.NoteDelete == false).ToList();
        }

        public List<Note> GetNoteListWithWriter()
        {
            return _notDal.GetListWithWriter();
        }

        public void Delete(Note note)
        {
            _notDal.Delete(note);
        }

        public void Insert(Note note)
        {
            _notDal.Insert(note);
        }

        public void Update(Note note)
        {
            _notDal.Update(note);
        }
    }
}
