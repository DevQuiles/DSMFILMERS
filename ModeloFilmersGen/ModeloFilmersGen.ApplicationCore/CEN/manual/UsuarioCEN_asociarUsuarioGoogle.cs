
using System;
using System.Text;
using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Usuario_asociarUsuarioGoogle) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
public partial class UsuarioCEN
{
public void AsociarUsuarioGoogle (string p_oid, string p_IdGoogle)
{
            /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Usuario_asociarUsuarioGoogle) ENABLED START*/

            UsuarioEN usuarioEN = DamePorOID(p_oid);

            usuarioEN.UsuarioGoogle = p_IdGoogle;

            _IUsuarioRepository.ModificarUsuario(usuarioEN);



            /*PROTECTED REGION END*/
        }
}
}
