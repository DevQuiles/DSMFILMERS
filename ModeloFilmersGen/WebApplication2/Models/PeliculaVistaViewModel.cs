using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class PeliculaVistaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set;}

        [Display(Prompt = "Comenta la película", Description = "Cometario de la película", Name = "Comentario")]
        [Required(ErrorMessage = "Debe indicar un comentario para la película")]
        [StringLength(maximumLength: 200, ErrorMessage = "El comentario no puede tener más de 200 caracteres")]
        public string comentario { get; set; }

        [Display(Prompt = "Valora la película", Description = "Valoración de la película", Name = "Valoración")]
        [Required(ErrorMessage = "Debe indicar una valoración para la película")]
        [StringLength(maximumLength: 200, ErrorMessage = "La valoración no puede tener más de 200 caracteres")]

        public Enum valoracion { get; set;}

        [Display(Prompt = "Fecha para la película", Description = "Fecha de la película", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar una fecha para la película")]
        [StringLength(maximumLength: 200, ErrorMessage = "La Fecha no puede tener más de 200 caracteres")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida tiene que tener un formato válido")]

        public DateTime fecha { get; set; }
    }
}
