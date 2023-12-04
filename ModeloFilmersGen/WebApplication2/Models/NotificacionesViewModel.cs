using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class NotificacionesViewModel
    {
        [ScaffoldColumn(true)]
        public DateTime Fecha { get; set; }

        [ScaffoldColumn(true)]
        public String Contenido { get; set; }

        [ScaffoldColumn(true)]
        public Boolean Estado { get; set; }

        [ScaffoldColumn(true)]
        public Boolean Destacada { get; set; }

        [ScaffoldColumn(false)]
        public String IdUsuario { get; set; }
    }
}
