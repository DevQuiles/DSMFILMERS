using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApplication2.Models;


namespace WebApplication2.Assemblers
{
    public class PlaylistAssembler
    {

        public PlaylistViewModel ConvertirEnToViewModel (PlaylistEN en)
        {
            PlaylistViewModel play = new PlaylistViewModel ();
            play.Id = en.Id;
            play.Descripcion = en.Descripcion;
            play.nombre = en.Nombre;

            //play.IdUsuario = en.Propietario.Email;

            return play;
        }

        public IList<PlaylistViewModel> ConvertirListEnToViewModel (IList<PlaylistEN> ens)
        {
            IList<PlaylistViewModel> plays = new List<PlaylistViewModel> ();
            foreach (PlaylistEN en in ens)
            {
                plays.Add (ConvertirEnToViewModel (en));
            }

            return plays;
        }
    }
}
