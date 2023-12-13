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
            peli.Pelicula = new PeliculaViewModel
            {
                Id = en.Pelicula.Id,
                nombre = en.Pelicula.Nombre,
                caratula = en.Pelicula.Caratula,
                Descripcion = en.Pelicula.Descripcion,
                fecha = (DateTime)en.Pelicula.Fecha,
                genero = en.Pelicula.Genero,
                duracion = en.Pelicula.Duracion,
                puntuacion = en.Pelicula.Puntuacion,
                estado = en.Pelicula.Estado,  
            };

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
