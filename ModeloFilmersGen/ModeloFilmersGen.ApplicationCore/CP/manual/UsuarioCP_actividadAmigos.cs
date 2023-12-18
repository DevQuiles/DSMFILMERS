
using System;
using System.Text;

using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;



/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Usuario_actividadAmigos) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto
{
public partial class UsuarioCP : GenericBasicCP
{
public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> ActividadAmigos (string p_oid)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Usuario_actividadAmigos) ENABLED START*/

        UsuarioCEN usuarioCEN = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                usuarioCEN = new  UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);

                PeliculaVistaCEN peliculaVistaCEN = new PeliculaVistaCEN (CPSession.UnitRepo.PeliculaVistaRepository);



                UsuarioEN usuarioConsulta = usuarioCEN.DamePorOID (p_oid);
                IList<PeliculaVistaEN> resultado = new List<PeliculaVistaEN>();
                if (usuarioConsulta.Seguidos != null && usuarioConsulta.Seguidos.Any ()) {
                        IList<UsuarioEN> listaSeguidos = usuarioConsulta.Seguidos;


                        foreach (var user in listaSeguidos) {
                                var ultimasTresPeliculas = user.PeliculasVistas
                                                           .OrderByDescending (p => p.Fecha)
                                                           .Take (3)
                                                           .ToList ();

                                foreach (var pelicula in ultimasTresPeliculas) {
                                        resultado.Add (pelicula);
                                }
                        }

                        // Ordenar la lista acumulativa por fecha
                        resultado = resultado.OrderByDescending (p => p.Fecha).ToList ();
                }


                CPSession.Commit ();
                return resultado;
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


        /*PROTECTED REGION END*/
}
}
}
