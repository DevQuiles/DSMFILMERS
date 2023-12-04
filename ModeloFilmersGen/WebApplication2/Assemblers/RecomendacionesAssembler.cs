

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using WebApplication2.Models;

namespace WebApplication2.Assemblers
{
    public class RecomendacionesAssembler
    {
        public RecomendacionesViewModel ConvertirENToViewModel(RecomendacionesEN en)
        {

            RecomendacionesViewModel rec = new RecomendacionesViewModel();
            rec.Recomendador = en.Recomendador.NomUsuario;
            rec.Recomendado = en.Recomendado.NomUsuario;
            rec.Pelicula = en.Pelicula.Nombre;
            rec.idPelicula = en.Pelicula.Id;


            return rec;
        }

        public IList<RecomendacionesViewModel> ConvertirListENToViewModel(IList<RecomendacionesEN> ens)
        {
            IList<RecomendacionesViewModel> recs = new List<RecomendacionesViewModel>();
            foreach (RecomendacionesEN en in ens)
            {
                recs.Add(ConvertirENToViewModel(en));
            }
            return recs;
        }

    }
}
