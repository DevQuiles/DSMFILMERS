using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;



namespace WebApplication2.Models
{
    public class PlaylistViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string caratula { get; set; }

        [Display(Prompt = "Un nombre para la playlist", Description = "Nombre de la playlist", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para la playlist")]
        [StringLength(maximumLength: 100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Describe la playlist", Description = "Descripción de la playlist", Name = "Descripcion de la playlist")]
        [Required(ErrorMessage = "Debe indicar una descripcion para la playlist")]
        [StringLength(maximumLength:200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [ScaffoldColumn(false)]
        public String IdUsuario { get; set; }
    }
}
