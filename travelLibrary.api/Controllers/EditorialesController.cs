using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using travelLibrary.AccesoDatos.Data;
using travelLibrary.AccesoDatos.Data.Repository.IRepository;
using travelLibrary.Models;

namespace travelLibrary.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditorialesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo; 
        private readonly MyDBContext _Context;

        public EditorialesController(IContenedorTrabajo contenedorTrabajo , MyDBContext  dbContext)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _Context = dbContext;

        }
        #region Llamadas a la Api
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Json(  _contenedorTrabajo.Editorial.GetAll() );
        }

        [HttpGet("[action]")]
        public IActionResult GetLibrosEditorial( int idEditorial )
        {
            return Json(_contenedorTrabajo.Libro.GetAll(s=> s.Editoriales_id == idEditorial ));
        }

        [HttpPost]
         
        public IActionResult Create(Editoriales editorial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (editorial.Id == 0)
                    {
                        _contenedorTrabajo.Editorial.Add(editorial);
                        _contenedorTrabajo.Save();
                        return Ok(Json(_contenedorTrabajo.Editorial.GetAll()));
                    }
                    return BadRequest("Editorial ya existe");
                }
                return BadRequest("Modelo invalido");
           } catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPut]
        public IActionResult Editar(Editoriales editorial)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    if (editorial.Id != 0)
                    {  
                        _contenedorTrabajo.Editorial.update(editorial);
                        _contenedorTrabajo.Save();
                        return Ok(Json(_contenedorTrabajo.Editorial.GetAll()));
                    }
                    return BadRequest("Editorial no existe");
                }
                return BadRequest("Modelo invalido");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            { 
                if (id == 0)
                    {
                        return BadRequest("Id no existe");
                    }
                Editoriales editorial = _contenedorTrabajo.Editorial.GetFirstOrDefault(s => s.Id == id );
                if (editorial != null) {
                    Libros libro = _contenedorTrabajo.Libro.GetFirstOrDefault(l => l.Editoriales_id == editorial.Id);
                    if (libro != null)
                        {
                            return BadRequest("Editorial esta relacionado a uno o más libros");
                        }

                    _contenedorTrabajo.Editorial.Remove(editorial);
                    _contenedorTrabajo.Save();
                    return Ok(Json(_contenedorTrabajo.Editorial.GetAll()));
                }
                return BadRequest("Editorial no existe"); 
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

    }

    #endregion

}
