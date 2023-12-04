using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class RecomendacionesViewModel
    {
        [ScaffoldColumn(true)]
        public DateTime Fecha { get; set; }

        [ScaffoldColumn(true)]
        public String Recomendador { get; set; }

        [ScaffoldColumn(true)]
        public String Recomendado { get; set; }

        [ScaffoldColumn(true)]
        public String Pelicula { get; set; }

        [ScaffoldColumn(true)]
        public int idPelicula { get; set; }
    }
}
