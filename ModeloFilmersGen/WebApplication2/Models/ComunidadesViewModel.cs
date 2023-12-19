using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ComunidadesViewModel
    {
        [ScaffoldColumn(false)]
        public int IdCom { get; set; }


        [Display(Prompt = "Describe la comunidad", Description = "Descripción de la comunidad", Name = "Descripción")]
        [Required(ErrorMessage = "Debe indicar una descripcion para la comunidad")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }


        [Display(Prompt = "Introduce el nombre de la comunidad", Description = "Nombre de la comunidad", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 50, ErrorMessage = "La descripción no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }


        [ScaffoldColumn(false)]
        [Display(Prompt = "Introduce fecha de creación", Description = "Fecha de creacion de la comunidad", Name = "Fecha de creación")]
        [Required(ErrorMessage = "Debe indicar la fecha de creacion")]
        public DateOnly FechaCreacion { get; set; }


        [ScaffoldColumn(false)]
        [Display(Prompt = "Introduce el usuario emisor", Description = "Usuario emisor de la comunidad", Name = "Usuario emisor")]
        [Required(ErrorMessage = "Debe indicar el usuario emisor")]
        public String Emisor { get; set; }

    }
}