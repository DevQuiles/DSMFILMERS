
using System;
using System.Text;
using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Usuario_recogerRecompensa) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
public partial class UsuarioCEN
{
public void RecogerRecompensa (string p_oid)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto_Usuario_recogerRecompensa) ENABLED START*/

        UsuarioEN usuario = DamePorOID (p_oid);

        usuario.RecompensaDisponible = false;

        _IUsuarioRepository.ModificarUsuario (usuario);

        /*PROTECTED REGION END*/
}
}
}
