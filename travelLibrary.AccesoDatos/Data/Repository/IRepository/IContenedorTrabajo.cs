using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelLibrary.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    { 
        
        //agregar cada repositorio creado
        IAutorRepository Autor { get; }
        IAutorHasLibroRepository AutorHasLibro{ get; }
        IEditorialRepository Editorial { get; } 
        ILibroRepository Libro { get; }
        void Save();

    }
}
