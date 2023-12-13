
using System;
using System.Text;

using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;



/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Playlist_combinarPlaylists) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto
{
public partial class PlaylistCP : GenericBasicCP
{
public int CombinarPlaylists (int p_oid, int p_oid2)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Playlist_combinarPlaylists) ENABLED START*/

        PlaylistCEN playlistCEN = null;

        int result = -1;


        try
        {
                CPSession.SessionInitializeTransaction ();
                playlistCEN = new  PlaylistCEN (CPSession.UnitRepo.PlaylistRepository);



                //        Te guardas las dos playlists
                //        Generas una combinacion de ambas:
                //        ->Nombre : COMBINADAS (NOMBRE1) + (NOMBRE2)
                //        ->Sin descripcion (se borra)
                //        -> Una concatenacion de las peliculas sin repes



                PlaylistEN playlist1 = playlistCEN.DamePorOID (p_oid);
                PlaylistEN playlist2 = playlistCEN.DamePorOID (p_oid2);


                int nuevaplaylist = playlistCEN.CrearPlaylist ("COMIBINACION " + playlist1.Nombre + playlist2.Nombre, "SIN DESCRIPCION", playlist1.Propietario.Email);

                IList<PeliculaEN> list1 = playlist1.Peliculas;
                IList<PeliculaEN> list2 = playlist2.Peliculas;
                List<int> combi = new List<int>();

                foreach (PeliculaEN p in list2) {
                        combi.Add (p.Id);
                }


                foreach (PeliculaEN p in list1) {
                        if (!combi.Contains (p.Id)) {
                                combi.Add (p.Id);
                        }
                }

                //Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!ATENZIONE");

                //Console.WriteLine(combi.Count);

                playlistCEN.AsignarPeliculas (nuevaplaylist, combi);

                CPSession.Commit ();

                return nuevaplaylist;
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
