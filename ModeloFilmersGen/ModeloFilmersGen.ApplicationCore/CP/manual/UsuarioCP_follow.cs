
using System;
using System.Text;

using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using System.Linq;



/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Usuario_follow) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto
{
    public partial class UsuarioCP : GenericBasicCP
    {
        public void Follow(string p_usuarioSeguidor, string p_usuarioSeguido)
        {
            /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Usuario_follow) ENABLED START*/

            UsuarioCEN usuarioCEN = null;

            try
            {
                CPSession.SessionInitializeTransaction();
                usuarioCEN = new UsuarioCEN(CPSession.UnitRepo.UsuarioRepository);
                NotificacionesCEN notiCEN = new NotificacionesCEN(CPSession.UnitRepo.NotificacionesRepository);


                UsuarioEN usuariosSeguidorEN = usuarioCEN.DamePorOID(p_usuarioSeguidor);
                IList<UsuarioEN> seguidos = usuariosSeguidorEN.Seguidos;

                UsuarioEN usuarioSeguidoEN = usuarioCEN.DamePorOID(p_usuarioSeguido);
                bool repetidos = seguidos.Any(usuario => usuario.Email == usuarioSeguidoEN.Email);
                if (repetidos)
                {
                    Console.WriteLine("El usuario al que intentas seguir ya los siges");
                    return;
                }



                usuarioCEN.AsignarSeguidores(p_usuarioSeguido, new List<string> { p_usuarioSeguidor });

                int i = notiCEN.CrearNotificacion("Te ha seguido  --> " + usuariosSeguidorEN.NomUsuario, p_usuarioSeguido, DateTime.Now, false, false);

                Console.WriteLine(notiCEN.DamePorOID(i).Contenido);

                CPSession.Commit();
            }
            catch (Exception ex)
            {
                CPSession.RollBack();
                throw ex;
            }
            finally
            {
                CPSession.SessionClose();
            }

            /*PROTECTED REGION END*/
        }
    }
}
