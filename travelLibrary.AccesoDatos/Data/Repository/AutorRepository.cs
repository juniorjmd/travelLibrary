using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using travelLibrary.AccesoDatos.Data.Repository.IRepository;
using travelLibrary.Models;

namespace travelLibrary.AccesoDatos.Data.Repository
{
    internal class AutorRepository : Repository<Autores>, IAutorRepository
    {private readonly MyDBContext _db;
        public AutorRepository(MyDBContext  db  ) : base( db ) { _db = db;} 
        public IEnumerable<SelectListItem> GetListaAutores()
        {
            return _db.Autores.Select(i => new SelectListItem()
                {
                    Text = i.Nombre + " " + i.Apellido,
                    Value = i.Id.ToString()
                }
            );
        }

        public void update(Autores autores)
        {
             var objDesdeDB = _db.Autores.FirstOrDefault(aut => aut.Id == autores.Id );

            objDesdeDB.Nombre = autores.Nombre;
            objDesdeDB.Apellido = autores.Apellido;

            _db.SaveChanges();




        }
    }
}
