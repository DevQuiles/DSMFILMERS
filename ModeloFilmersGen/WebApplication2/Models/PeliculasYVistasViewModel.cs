using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;

namespace WebApplication2.Models
{
    public class PeliculasYVistasViewModel
    {
        public IEnumerable<PeliculaViewModel> Peliculas { get; set; }
        public IEnumerable<PeliculaVistaViewModel> UltimasVistas { get; set; }
    }
}
