using travelLibrary.AccesoDatos.Data.Repository.IRepository;
using travelLibrary.Models;

namespace travelLibrary.AccesoDatos.Data.Repository
{
    internal class AutorHasLibroRepository : Repository<Autores_has_libros> , IAutorHasLibroRepository
    {

        private readonly MyDBContext _db;
        public AutorHasLibroRepository(MyDBContext db) : base(db) { _db = db; }
       
        public void update(Autores_has_libros AutorHasLibro)
        {
            var objDatabase = _db.Autores_has_libros.FirstOrDefault(s => s.Libros_ISBN == AutorHasLibro.Libros_ISBN);
            objDatabase.Autores_id = AutorHasLibro.Autores_id;
            _db.SaveChanges();
        }
    }
}
