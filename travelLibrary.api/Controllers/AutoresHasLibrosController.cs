using Microsoft.AspNetCore.Mvc;
using travelLibrary.AccesoDatos.Data.Repository.IRepository;
using travelLibrary.AccesoDatos.Data;
using travelLibrary.Models;

namespace travelLibrary.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresHasLibrosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly MyDBContext _Context;

        public AutoresHasLibrosController(IContenedorTrabajo contenedorTrabajo, MyDBContext dbContext)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _Context = dbContext;

        }
        public List<Autores> GetAutoresLibro(int id)
        {
            List<Autores_has_libros> librosAutor = _contenedorTrabajo.AutorHasLibro.GetAll(s => s.Libros_ISBN == id).ToList<Autores_has_libros>();
            List<Autores> listaFinal = new List<Autores>();
            librosAutor.ForEach(lib =>
            {
                listaFinal.Add(_contenedorTrabajo.Autor.GetFirstOrDefault(l => l.Id == lib.Autores_id));
            });
            return listaFinal ;
        }



        #region Llamadas a la Api
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Json( _contenedorTrabajo.AutorHasLibro.GetAll() );
        }

        [HttpGet("[action]")]
        public IActionResult GetLibrosAutor( int id)
        {
            List<Autores_has_libros> librosAutor = _contenedorTrabajo.AutorHasLibro.GetAll(s => s.Autores_id == id).ToList< Autores_has_libros>();
            List<Libros> listaFinal = new List<Libros>();
            librosAutor.ForEach(lib =>
            { 
                listaFinal.Add(_contenedorTrabajo.Libro.GetFirstOrDefault(l => l.ISBN == lib.Libros_ISBN));
            });
                return Json(listaFinal);
        }
 

        #endregion
    }
}
