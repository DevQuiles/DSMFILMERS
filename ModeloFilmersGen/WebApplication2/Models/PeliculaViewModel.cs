using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class PeliculaViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Display(Prompt = "Un nombre para la playlist", Description = "Nombre de la playlist", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para la playlist")]
        [StringLength(maximumLength: 100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Caratula para la playlist", Description = "Caratula de la playlist", Name = "Caratula")]
        [Required(ErrorMessage = "Debe poner una caratula para la playlist")]
        [StringLength(maximumLength: 100, ErrorMessage = "La caratula no puede tener más de 100 caracteres")]
        public string caratula { get; set; }

        [Display(Prompt = "Describe la película", Description = "Descripción de la película", Name = "Descripción")]
        [Required(ErrorMessage = "Debe indicar una descripción para la película")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Fecha para la película", Description = "Fecha de la película", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar una fecha para la película")]
        [StringLength(maximumLength: 200, ErrorMessage = "La fecha no puede tener más de 200 caracteres")]
        [DataType(DataType.Date, ErrorMessage = "La fecha introducida tiene que tener un formato válido")]

        public DateTime fecha { get; set; }

        [Display(Prompt = "Un género de la película", Description = "Genéro de la película", Name = "Género")]
        [Required(ErrorMessage = "Debe indicar un género para la película")]
        [StringLength(maximumLength: 100, ErrorMessage = "El género no puede tener más de 100 caracteres")]
        public IList<string> genero { get; set; }

        [Display(Prompt = "Una duración de la película", Description = "Duración de la película", Name = "Duración")]
        [Required(ErrorMessage = "Debe indicar una duración para la película")]
        [Range(minimum: 0, maximum: 500, ErrorMessage = "La duración debe ser mayor que 0 y menos que 500")]
        public int duracion { get; set; }

        [Display(Prompt = "Una puntuación de la película", Description = "Puntuación de la película", Name = "Puntuación")]
        [Required(ErrorMessage = "Debe indicar una puntuación para la película")]
        [Range(minimum: 0, maximum: 11, ErrorMessage = "La puntuación debe ser mayor que 0 y menos que 11")]
        public double puntuacion { get; set; }

        [Display(Prompt = "Un estado de la película", Description = "Estado de la película", Name = "Estado")]
        [Required(ErrorMessage = "Debe indicar un estado para la película")]
        [StringLength(maximumLength: 100, ErrorMessage = "El estado no puede tener más de 100 caracteres")]
        public string estado { get; set; }




    }
}
