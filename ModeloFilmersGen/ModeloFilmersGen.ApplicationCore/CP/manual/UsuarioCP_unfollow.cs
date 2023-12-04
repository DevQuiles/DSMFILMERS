
using System;
using System.Text;

using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;



/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Usuario_unfollow) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto
{
public partial class UsuarioCP : GenericBasicCP
{
public void Unfollow (string p_seguidor, string p_seguido)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Usuario_unfollow) ENABLED START*/

        UsuarioCEN usuarioCEN = null;

        try
        {
                CPSession.SessionInitializeTransaction ();
                usuarioCEN = new UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);
                NotificacionesCEN notiCEN = new NotificacionesCEN (CPSession.UnitRepo.NotificacionesRepository);


                UsuarioEN usEN = usuarioCEN.DamePorOID (p_seguidor);
                IList<UsuarioEN> seguidos = usEN.Seguidos;

                usuarioCEN.DesasignarSeguidores (p_seguido, new List<string> { p_seguidor });

                int i = notiCEN.CrearNotificacion ("Te ha dejado seguir --> " + p_seguidor, p_seguido, DateTime.Now, false, false);

                Console.WriteLine (notiCEN.DamePorOID (i).Contenido);

                CPSession.Commit ();
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
