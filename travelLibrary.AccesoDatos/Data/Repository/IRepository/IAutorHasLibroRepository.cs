
using travelLibrary.Models;

namespace travelLibrary.AccesoDatos.Data.Repository.IRepository
{
    public interface IAutorHasLibroRepository : IRepository<Autores_has_libros>
    {
        void update(Autores_has_libros AutorHasLibro);
    }
}
