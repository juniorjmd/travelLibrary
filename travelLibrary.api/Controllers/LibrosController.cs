using Microsoft.AspNetCore.Mvc;
using travelLibrary.AccesoDatos.Data.Repository.IRepository;
using travelLibrary.AccesoDatos.Data;
using travelLibrary.Models;

namespace travelLibrary.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly MyDBContext _Context;

        public LibrosController(IContenedorTrabajo contenedorTrabajo, MyDBContext dbContext)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _Context = dbContext;

        }

        #region Llamadas a la Api
        [HttpGet("[action]")]
        public IActionResult GetAll() {
            List<Libros> Libros = _contenedorTrabajo.Libro.GetAll().ToList<Libros>();
            List<LibrosAuxiliar> Librosfinal = new List<LibrosAuxiliar>();
            Libros.ForEach(lib =>
            {   LibrosAuxiliar  auxLib = new LibrosAuxiliar();
                auxLib.Editorial = _contenedorTrabajo.Editorial.GetFirstOrDefault(x => x.Id == lib.Editoriales_id);
                AutoresHasLibrosController librosAutores = new AutoresHasLibrosController(_contenedorTrabajo , _Context);
                auxLib.Autores = librosAutores.GetAutoresLibro(lib.ISBN);
                auxLib.ISBN = lib.ISBN;
                auxLib.Editoriales_id = lib.Editoriales_id;
                auxLib.Titulo = lib.Titulo;
                auxLib.Sinopsis = lib.Sinopsis;
                auxLib.n_paginas = lib.n_paginas;

                Librosfinal.Add(auxLib);
               });
            return Json(Librosfinal);
        }





        [HttpPost] 
        public IActionResult Create(LibrosAuxiliar libroCompleto )
        {
            try
            {
                Autores_has_libros autorLibro = new Autores_has_libros();
                if (ModelState.IsValid)
                {
                    if (libroCompleto.ISBN == 0)
                    {   if (libroCompleto.Autores == null) { return BadRequest("El libro de contener uno o mas autores"); }
                        Libros libro = new Libros();
                        libro.ISBN = libroCompleto.ISBN;
                        libro.Titulo = libroCompleto.Titulo;
                        libro.Sinopsis = libroCompleto.Sinopsis;
                        libro.n_paginas = libroCompleto.n_paginas;
                        libro.Editoriales_id = libroCompleto.Editoriales_id;
                        _contenedorTrabajo.Libro.Add(libro);
                        _contenedorTrabajo.Save(); 
                        List<Autores> autores = libroCompleto.Autores;
                        autores.ForEach(autor => {
                            Autores_has_libros autorLibro = new Autores_has_libros();
                            autorLibro.Autores_id = autor.Id;
                            autorLibro.Libros_ISBN = libro.ISBN;
                            _contenedorTrabajo.AutorHasLibro.Add(autorLibro);
                            _contenedorTrabajo.Save();
                        });

                        return Ok(this.GetAll());
                    }
                    return BadRequest("libro ya existe");
                }
                return BadRequest("Modelo invalido");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPut]
        public IActionResult Editar(LibrosAuxiliar libroCompleto)
        {
            try
            { Libros libro = new Libros();
                if (ModelState.IsValid)
                {
                    libro.ISBN = libroCompleto.ISBN;
                    libro.Titulo = libroCompleto.Titulo;
                    libro.Sinopsis = libroCompleto.Sinopsis;
                    libro.n_paginas = libroCompleto.n_paginas;
                    libro.Editoriales_id = libroCompleto.Editoriales_id;
                    if (libro.ISBN != 0)
                    {
                        _contenedorTrabajo.Libro.update(libro);
                        _contenedorTrabajo.Save();
                        Autores_has_libros autorLibro ;
                        do {
                            autorLibro = _contenedorTrabajo.AutorHasLibro.GetFirstOrDefault(ahl => ahl.Libros_ISBN == libro.ISBN);
                            if (autorLibro != null) {
                                _contenedorTrabajo.AutorHasLibro.Remove(autorLibro);
                                _contenedorTrabajo.Save();
                            }
                        }
                        while (autorLibro != null);
                        libroCompleto.Autores.ForEach(autor =>
                        {
                            autorLibro = new Autores_has_libros();
                            autorLibro.Autores_id = autor.Id;
                            autorLibro.Libros_ISBN = libro.ISBN;
                            _contenedorTrabajo.AutorHasLibro.Add(autorLibro);
                            _contenedorTrabajo.Save();
                        });
                        return Ok(this.GetAll());
                    }
                    return BadRequest("libro no existe");
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
                Libros libro = _contenedorTrabajo.Libro.GetFirstOrDefault(s => s.ISBN == id);
                if (libro != null)
                {  
                    _contenedorTrabajo.Libro.Remove(libro);
                    _contenedorTrabajo.Save();
                    Autores_has_libros autorLibro;
                    do
                    {
                        autorLibro = _contenedorTrabajo.AutorHasLibro.GetFirstOrDefault(ahl => ahl.Libros_ISBN == id);
                        if (autorLibro != null)
                        {
                            _contenedorTrabajo.AutorHasLibro.Remove(autorLibro);
                            _contenedorTrabajo.Save();
                        }
                    }
                    while (autorLibro != null);
                    return Ok(this.GetAll());
                }
                return BadRequest("libro no existe");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }






        #endregion
    }




}
