
using System;
using System.Text;
using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Usuario_modificarUsuario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
public partial class UsuarioCEN
{
public void ModificarUsuario (string p_Usuario_OID, string p_nomUsuario, string p_nombre, Nullable<DateTime> p_fechaNac, string p_localidad, string p_pais, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum p_nivel, String p_pass, bool p_recompensaDisponible, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum p_avatarIcon)
{
            /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Usuario_modificarUsuario_customized) START*/
            
            UsuarioEN en = _IUsuarioRepository.ReadOIDDefault(p_Usuario_OID);
            UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.NomUsuario = p_nomUsuario;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.FechaNac = p_fechaNac;
        usuarioEN.Localidad = p_localidad;
        usuarioEN.Pais = p_pais;
        usuarioEN.Nivel = p_nivel;
            if (p_pass == en.Pass)
            {
                usuarioEN.Pass = p_pass;
            }
            else
            {
                usuarioEN.Pass = Utils.Util.GetEncondeMD5(p_pass);
            }
        usuarioEN.RecompensaDisponible = p_recompensaDisponible;
        usuarioEN.AvatarIcon = p_avatarIcon;
        //Call to UsuarioRepository

        _IUsuarioRepository.ModificarUsuario (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
