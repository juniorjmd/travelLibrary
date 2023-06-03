using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace travelLibrary.Models
{
    public class Autores
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre para el autor")]
        [Display(Name = "Nombre Autor")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Autor")]
        public string? Apellido { get; set; }  
    }
}
