﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-73I52K7; database=DiaryDb; integrated security=True; TrustServerCertificate=True;");
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
