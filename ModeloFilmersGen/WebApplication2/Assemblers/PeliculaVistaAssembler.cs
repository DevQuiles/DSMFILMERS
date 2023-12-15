using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Assemblers
{
    public class PeliculaVistaAssembler
    {
        public PeliculaVistaViewModel ConvertirEnToViewModel(PeliculaVistaEN en)
        {
            PeliculaVistaViewModel peli = new PeliculaVistaViewModel();
            peli.Id = en.Id;
            peli.comentario = en.Comentario;
            peli.valoracion = en.Valoracion;
            peli.fecha = (DateTime)en.Fecha;
            peli.idPelicula = en.Pelicula.Id;

            return peli;
        }

        public IList<PeliculaVistaViewModel> ConvertirListEnToViewModel(IList<PeliculaVistaEN> ens)
        {
            IList<PeliculaVistaViewModel> pelis = new List<PeliculaVistaViewModel>();
            foreach (PeliculaVistaEN en in ens)
            {
                pelis.Add(ConvertirEnToViewModel(en));
            }

            return pelis;
        }
    }
}
