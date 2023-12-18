

using System;
using System.Text;
using System.Collections.Generic;

using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using Newtonsoft.Json;


namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}

public string CrearUsuario (string p_email, string p_nomUsuario, string p_nombre, Nullable<DateTime> p_fechaNac, string p_localidad, string p_pais, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.NivelesEnum p_nivel, String p_pass, bool p_recompensaDisponible, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.AvatarEnum p_avatarIcon)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.NomUsuario = p_nomUsuario;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.FechaNac = p_fechaNac;

        usuarioEN.Localidad = p_localidad;

        usuarioEN.Pais = p_pais;

        usuarioEN.Nivel = p_nivel;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioEN.RecompensaDisponible = p_recompensaDisponible;

        usuarioEN.AvatarIcon = p_avatarIcon;



        oid = _IUsuarioRepository.CrearUsuario (usuarioEN);
        return oid;
}

public void BorrarUsuario (string email
                           )
{
        _IUsuarioRepository.BorrarUsuario (email);
}

public UsuarioEN DamePorOID (string email
                             )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioRepository.DamePorOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioRepository.DameTodos (first, size);
        return list;
}
public void AsignarPeliculaWatchList (string p_Usuario_OID, System.Collections.Generic.IList<int> p_deseadas_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.AsignarPeliculaWatchList (p_Usuario_OID, p_deseadas_OIDs);
}
public void DesasignarPeliculaWatchList (string p_Usuario_OID, System.Collections.Generic.IList<int> p_deseadas_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.DesasignarPeliculaWatchList (p_Usuario_OID, p_deseadas_OIDs);
}
public void AsignarSeguidores (string p_Usuario_OID, System.Collections.Generic.IList<string> p_seguidores_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.AsignarSeguidores (p_Usuario_OID, p_seguidores_OIDs);
}
public void DesasignarSeguidores (string p_Usuario_OID, System.Collections.Generic.IList<string> p_seguidores_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.DesasignarSeguidores (p_Usuario_OID, p_seguidores_OIDs);
}
public void AsignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comunidades_0_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.AsignarComunidad (p_Usuario_OID, p_comunidades_0_OIDs);
}
public void DesasignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comunidades_0_OIDs)
{
        //Call to UsuarioRepository

        _IUsuarioRepository.DesasignarComunidad (p_Usuario_OID, p_comunidades_0_OIDs);
}
public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> DameUsuarioPorNombre (string p_nombre)
{
        return _IUsuarioRepository.DameUsuarioPorNombre (p_nombre);
}
public string Login (string p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Email);

        return result;
}




private string Encode (string email)
{
        var payload = new Dictionary<string, object>(){
                { "email", email }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string email)
{
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (email);
        string token = Encode (en.Email);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerEMAIL (decodedToken);

                UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (id);

                if (en != null && ((string)en.Email).Equals (ObtenerEMAIL (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerEMAIL (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string email = (string)results ["email"];
                return email;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
