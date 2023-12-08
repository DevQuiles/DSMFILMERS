using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class PeliculaViewModel
    {
        
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre de la película", Description = "Nombre de la Película", Name = "Nombre")]
        [Required(ErrorMessage = "El nombre de la película es obligatorio")]
        [StringLength(200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "URL de la carátula", Description = "Carátula de la Película", Name = "Carátula")]
        [StringLength(500, ErrorMessage = "La URL de la carátula no puede tener más de 500 caracteres")]
        public string Caratula { get; set; }

        [Display(Prompt = "Descripción de la película", Description = "Descripción de la Película", Name = "Descripción")]
        [StringLength(1000, ErrorMessage = "La descripción no puede tener más de 1000 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Fecha de estreno", Description = "Fecha de Estreno de la Película", Name = "Fecha de estreno")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de estreno es obligatoria")]
        public DateTime Fecha { get; set; }

        [Display(Prompt = "Género de la película", Description = "Género de la Película", Name = "Genero")]
        [Required(ErrorMessage = "El género de la película es obligatorio")]
        public string Genero { get; set; }

        [Display(Prompt = "Duración en minutos", Description = "Duración de la Película", Name = "Duración")]
        [Range(1, 600, ErrorMessage = "La duración debe estar entre 1 y 600 minutos")]
        public int Duracion { get; set; }

        [Display(Prompt = "Puntuación de la película", Description = "Puntuación de la Película", Name = "Puntuación")]
        [Range(1, 10, ErrorMessage = "La puntuación debe estar entre 1 y 10")]
        public int Puntuacion { get; set; }

        [Display(Prompt = "Estado de la película", Description = "Estado de la Película", Name = "Estado")]
        [Required(ErrorMessage = "El estado de la película es obligatorio")]
        [StringLength(50, ErrorMessage = "El estado no puede tener más de 50 caracteres")]
        public string Estado { get; set; }
    }
}