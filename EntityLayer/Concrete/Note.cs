using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool NoteDelete { get; set; } = false;

        public int WriterId { get; set; }

        public Writer? Writer { get; set; }


    }






}
