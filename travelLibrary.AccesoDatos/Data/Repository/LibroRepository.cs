using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelLibrary.AccesoDatos.Data.Repository.IRepository;
using travelLibrary.Models;

namespace travelLibrary.AccesoDatos.Data.Repository
{
    public class LibroRepository : Repository<Libros>, ILibroRepository
    {
        private readonly MyDBContext _db;
        public LibroRepository (MyDBContext db) : base(db) { _db = db; }
        public void update(Libros libro)
        {
            var objDatabase = _db.Libros.FirstOrDefault(s => s.ISBN == libro.ISBN);
            objDatabase.n_paginas = libro.n_paginas;
            objDatabase.Titulo = libro.Titulo;
            objDatabase.Editoriales_id = libro.Editoriales_id;
            objDatabase.Sinopsis = libro.Sinopsis; 
            _db.SaveChanges();
        }
    }
}
