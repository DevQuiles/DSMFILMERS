using ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class MensajeViewModel
    {
        [ScaffoldColumn(false)]
        public int IdMensaje { get; set; }


        [Display(Prompt = "Escribe el contenido del mensaje", Description = "Mensaje de la comunidad", Name = "Mensaje")]
        [Required(ErrorMessage = "Debe escribir un mensaje para la comunidad")]
        [StringLength(maximumLength: 700, ErrorMessage = "El mensaje no puede tener mas de 700 caracteres")]
        public string Contenido { get; set; }

        [Display(Prompt = "Introduce fecha", Description = "Fecha del Mensaje", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar la fecha")]
        public DateOnly Fecha { get; set; }

        public int Dias { get; set; }

        public string Usuario { get; set; }
        public AvatarEnum Avatar{ get; set; }
        public string Comunidad { get; set; }
        public string ComunidadDescripcion { get; set; }


    }
}
