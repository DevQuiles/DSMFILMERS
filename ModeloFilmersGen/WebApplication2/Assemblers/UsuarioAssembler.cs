using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.CP;
using NHibernate;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertirENToViewModel(UsuarioEN en)
        {

            UsuarioViewModel usu = new UsuarioViewModel();
            usu.Email = en.Email;
            usu.Nombre = en.Nombre;
            usu.NombreUsuario = en.NomUsuario;
            usu.FechaNac = (DateTime)en.FechaNac;
            usu.Localidad = en.Localidad;
            usu.Pais = en.Pais;
            usu.Pass=en.Pass;
            usu.Nivel = en.Nivel;
            usu.Recompensa = en.RecompensaDisponible;
            usu.Avatar = en.AvatarIcon;
            usu.UsuariosSeguidos = new List<String> { };
            if (en.Seguidos.Count() != 0) {
                foreach (var seguidos in en.Seguidos)
                {
                    usu.UsuariosSeguidos.Add(seguidos.Email);
                }
            }
            
            

            usu.Seguidores = en.Seguidores.Count();
            usu.Seguidos = en.Seguidos.Count();
            usu.PelisVistas = en.PeliculasVistas.Count();


            return usu;
        }

        public IList<UsuarioViewModel> ConvertirListENToViewModel(IList<UsuarioEN> ens)
        {
            IList<UsuarioViewModel> usus = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                usus.Add(ConvertirENToViewModel(en));
            }
            return usus;
        }
    }
}
