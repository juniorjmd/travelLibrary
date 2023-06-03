using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travelLibrary.Models
{ 
    public class Autores_has_libros
    {
       
        [Key]
        public int Id { get; set; }
        public int Autores_id { get; set; }
        public int Libros_ISBN { get; set; }


        [ForeignKey("Autores_id")]
        public Autores Autor { get; set; }

        [ForeignKey("Libros_ISBN")]
        public Libros Libro { get; set; }
    }
}
