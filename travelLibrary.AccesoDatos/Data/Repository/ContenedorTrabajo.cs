using travelLibrary.AccesoDatos.Data.Repository.IRepository;

namespace travelLibrary.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly MyDBContext _db;
        public ContenedorTrabajo(MyDBContext  db)
        {
            _db = db;
            Autor = new AutorRepository(_db);
            AutorHasLibro = new AutorHasLibroRepository(_db);
            Editorial = new EditorialRepository(_db);
            Libro = new LibroRepository(_db);
        }
         

        public IAutorRepository Autor { get; private set; }

        public IAutorHasLibroRepository AutorHasLibro { get; private set; }

        public IEditorialRepository Editorial { get; private set; }

        public ILibroRepository Libro { get; private set; }

        public void Dispose()
        {
           _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
