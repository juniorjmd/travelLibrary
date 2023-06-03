using Microsoft.AspNetCore.Mvc;
using travelLibrary.AccesoDatos.Data.Repository.IRepository;
using travelLibrary.AccesoDatos.Data;
using travelLibrary.Models;

namespace travelLibrary.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly MyDBContext _Context;

        public AutoresController(IContenedorTrabajo contenedorTrabajo, MyDBContext dbContext)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _Context = dbContext;

        }
        #region Llamadas a la Api
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Json(   _contenedorTrabajo.Autor.GetAll()  );
        }

        [HttpPost]  
        public async Task<IActionResult> Create(Autores autores)
        {
            try { 

                if (ModelState.IsValid)
                {
                    _contenedorTrabajo.Autor.Add(autores);
                    _contenedorTrabajo.Save();

                    return Ok(Json(  _contenedorTrabajo.Autor.GetAll()  ));
                }
                return BadRequest("Modelo invalido");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
        [HttpPut]
        public IActionResult Editar(Autores autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (autor.Id != 0)
                    {
                        _contenedorTrabajo.Autor.update(autor);
                        _contenedorTrabajo.Save();
                        return Ok(Json(_contenedorTrabajo.Autor.GetAll()));
                    }
                    return BadRequest("autor no existe");
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
                Autores autor = _contenedorTrabajo.Autor.GetFirstOrDefault(s => s.Id == id);
                if (autor != null)
                {
                    Autores_has_libros AutorHasLibro = _contenedorTrabajo.AutorHasLibro.GetFirstOrDefault(l => l.Autores_id == autor.Id);
                    if (AutorHasLibro != null)
                    {
                        return BadRequest("El autor esta relacionado a uno o más libros");
                    }

                    _contenedorTrabajo.Autor.Remove(autor);
                    _contenedorTrabajo.Save();
                    return Ok(Json(_contenedorTrabajo.Autor.GetAll()));
                }
                return BadRequest("Autor no existe");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        #endregion
    }
}
