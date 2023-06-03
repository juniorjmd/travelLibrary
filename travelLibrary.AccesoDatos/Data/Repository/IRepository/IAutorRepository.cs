using travelLibrary.Models;
using System.Web.Mvc;

namespace travelLibrary.AccesoDatos.Data.Repository.IRepository
{
    public interface IAutorRepository : IRepository<Autores>
    { 
        IEnumerable<SelectListItem> GetListaAutores();
        void update (Autores autores);
    }
}
