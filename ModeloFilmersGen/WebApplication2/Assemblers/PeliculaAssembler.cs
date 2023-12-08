using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using WebApplication2.Models;
using System.Collections.Generic;

namespace WebApplication2.Assemblers
{
    public class PeliculaAssembler
    {
        public PeliculaViewModel ConvertirENToViewModel(PeliculaEN en)
        {
            // Suponiendo que PeliculaEN tiene propiedades correspondientes a PeliculaViewModel
            PeliculaViewModel peliculaVM = new PeliculaViewModel
            {
                Id = en.Id,
                Nombre = en.Nombre,
                Caratula = en.Caratula,
                Descripcion = en.Descripcion,
                Fecha = (DateTime)en.Fecha,
                Genero = en.Genero != null ? string.Join(", ", en.Genero) : "Género no especificado",
                Duracion = en.Duracion,
                Puntuacion = en.Puntuacion,
                Estado = en.Estado
            };

            return peliculaVM;
        }

        public IList<PeliculaViewModel> ConvertirListENToViewModel(IList<PeliculaEN> ens)
        {
            IList<PeliculaViewModel> peliculasVM = new List<PeliculaViewModel>();
            foreach (PeliculaEN en in ens)
            {
                peliculasVM.Add(ConvertirENToViewModel(en));
            }
            return peliculasVM;
        }
    }
}