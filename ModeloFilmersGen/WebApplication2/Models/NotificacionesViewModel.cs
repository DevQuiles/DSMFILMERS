using NHibernate.Linq.Functions;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class NotificacionesViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        public DateTime Fecha { get; set; }

      
        public String Contenido { get; set; }

      
        public Boolean Estado { get; set; }

       
        public Boolean Destacada { get; set; }

        [ScaffoldColumn(false)]
        public String IdUsuario { get; set; }

        public int idPelicula { get; set; }

        public string nombrePeli { get; set; }

        public String IdUsuarioEmisor {  get; set; }

        public ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum fotoUsuarioEmisor {  get; set; }

    }
}
