using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Assemblers
{
    public class NotificacionesAssembler
    {
        public NotificacionesViewModel ConvertirEnToViewModel(NotificacionesEN en)
        {

            NotificacionesViewModel not = new NotificacionesViewModel();
            not.Id = en.Id;
            not.Contenido = en.Contenido;
            not.IdUsuario = en.Usuario.Email;
            not.Destacada = en.Destacada;
            not.Estado = en.Estado;
            not.Fecha = (DateTime)en.Fecha;


            return not;
        }

        public IList<NotificacionesViewModel> ConvertirListEnToViewModel(IList<NotificacionesEN> ens)
        {
            IList<NotificacionesViewModel> nots = new List<NotificacionesViewModel>();
            foreach (NotificacionesEN en in ens)
            {
                nots.Add(ConvertirEnToViewModel(en));
            }
            return nots;
        }
    }
}