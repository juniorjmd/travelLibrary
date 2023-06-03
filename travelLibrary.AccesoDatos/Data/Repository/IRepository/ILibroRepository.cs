
using travelLibrary.Models;

namespace travelLibrary.AccesoDatos.Data.Repository.IRepository
{
    public interface ILibroRepository : IRepository<Libros>
    {
        void update(Libros libro);
    }
}
