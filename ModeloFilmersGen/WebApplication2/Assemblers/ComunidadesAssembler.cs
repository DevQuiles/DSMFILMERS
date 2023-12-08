using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using WebApplication2.Models;

namespace WebApplication2.Assemblers
{
    public class ComunidadesAssembler
    {

        public ComunidadesViewModel ConvertirENToViewModel(ComunidadesEN en)
        {
            ComunidadesViewModel com = new ComunidadesViewModel();
            com.IdCom = en.Id;
            com.Nombre = en.Nombre;
            com.Descripcion = en.Descripcion;
            com.FechaCreacion = (DateTime)en.FechaCreacion;
            com.Emisor = en.Creador_Emisor.NomUsuario;
            return com;
        }

        public IList<ComunidadesViewModel> ConvertirListENToViewModel(IList<ComunidadesEN> ens)
        {
            IList<ComunidadesViewModel> coms = new List<ComunidadesViewModel>();
            foreach (ComunidadesEN en in ens)
            {
                coms.Add(ConvertirENToViewModel(en));
            }
            return coms;
        }
    }
}
