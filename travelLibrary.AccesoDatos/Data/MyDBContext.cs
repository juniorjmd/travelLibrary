using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelLibrary.Models;

namespace travelLibrary.AccesoDatos.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options){  }
        public DbSet<Editoriales> Editoriales { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Autores_has_libros> Autores_has_libros { get; set; }
        public DbSet<Autores> Autores { get; set; }

    }
}
