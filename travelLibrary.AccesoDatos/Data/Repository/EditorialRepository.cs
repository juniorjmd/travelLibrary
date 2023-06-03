using Microsoft.EntityFrameworkCore;
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
    public class EditorialRepository : Repository<Editoriales>, IEditorialRepository
    {
        private readonly MyDBContext _db;
        public EditorialRepository(MyDBContext context) : base(context)
        {
            _db = context;

        }

        public IEnumerable<SelectListItem> GetListaEditoriales()
        {

            return _db.Autores.Select(i => new SelectListItem()
            {
                Text = i.Nombre  ,
                Value = i.Id.ToString()
            }
            );
        }

        public void update(Editoriales Editorial)
        {
            var objDesdeDB = _db.Editoriales.FirstOrDefault(e => e.Id == Editorial.Id);
            objDesdeDB.Nombre = Editorial.Nombre;
            objDesdeDB.Sede = Editorial.Sede;
            _db.SaveChanges();

        }
    }
}
