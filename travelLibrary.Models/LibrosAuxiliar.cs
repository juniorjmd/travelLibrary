using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace travelLibrary.Models
{
    public class LibrosAuxiliar
    {

        [Key]
        public int ISBN { get; set; }


        [Display(Name = "id Editorial")]

        [Required(ErrorMessage = "Debe ingresar una editorial")]
        public int Editoriales_id { get; set; }


        [Required(ErrorMessage = "Debe ingresar un titulo para el libro")]
        [Display(Name = "Titulo del libro")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(45)]
        public string Titulo { get; set; }
        [Column(TypeName = "TEXT")]
        public string Sinopsis { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(45)]
        public string n_paginas { get; set; }



        [ForeignKey("Editoriales_id")]
        public Editoriales? Editorial { get; set; }


        public List<Autores>? Autores { get; set; }

    }
}
