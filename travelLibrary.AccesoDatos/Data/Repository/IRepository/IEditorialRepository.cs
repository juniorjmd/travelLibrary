using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using travelLibrary.Models;

namespace travelLibrary.AccesoDatos.Data.Repository.IRepository
{
    public interface IEditorialRepository : IRepository<Editoriales>
    {
        IEnumerable<SelectListItem> GetListaEditoriales();
        void update(Editoriales Editorial);
    }
}
