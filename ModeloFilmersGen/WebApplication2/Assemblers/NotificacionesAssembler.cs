using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using WebApplication2.Models;

namespace WebApplication2.Assemblers
{
    public class NotificacionesAssembler
    {
        public NotificacionesViewModel ConvertirENToViewModel(NotificacionesEN en)
        {

            NotificacionesViewModel not = new NotificacionesViewModel();
            not.Contenido = en.Contenido;
            not.IdUsuario = en.Usuario.Email;
            not.Destacada = en.Destacada;
            //not.Estado=en.;
            ///////////////////PONER EN LUGAR DE ESTADO (ENUM LEIDO/NO LEIDO)  --> LEIDO (TRUE/FALSE)

            not.Fecha = (DateTime)en.Fecha;


            return not;
        }

        public IList<NotificacionesViewModel> ConvertirListENToViewModel(IList<NotificacionesEN> ens)
        {
            IList<NotificacionesViewModel> nots = new List<NotificacionesViewModel>();
            foreach (NotificacionesEN en in ens)
            {
                nots.Add(ConvertirENToViewModel(en));
            }
            return nots;
        }
    }
}
