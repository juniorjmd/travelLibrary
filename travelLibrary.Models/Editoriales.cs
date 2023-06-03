using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace travelLibrary.Models
{
    public class Editoriales
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre para la categoria")]
        [Display(Name = "Nombre Editorial")]
        public string Nombre { get; set; }
        [Display(Name = "Sede de la Editorial")]
        public string? Sede { get; set; }
    }
}
