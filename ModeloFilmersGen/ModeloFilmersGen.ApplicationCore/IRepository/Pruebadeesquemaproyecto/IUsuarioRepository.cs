
using System;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



string CrearUsuario (UsuarioEN usuario);

void ModificarUsuario (UsuarioEN usuario);


void BorrarUsuario (string email
                    );


UsuarioEN DamePorOID (string email
                      );


System.Collections.Generic.IList<UsuarioEN> DameTodos (int first, int size);


void AsignarPeliculaWatchList (string p_Usuario_OID, System.Collections.Generic.IList<int> p_deseadas_OIDs);

void DesasignarPeliculaWatchList (string p_Usuario_OID, System.Collections.Generic.IList<int> p_deseadas_OIDs);

void AsignarSeguidores (string p_Usuario_OID, System.Collections.Generic.IList<string> p_seguidores_OIDs);

void DesasignarSeguidores (string p_Usuario_OID, System.Collections.Generic.IList<string> p_seguidores_OIDs);

void AsignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comunidades_0_OIDs);

void DesasignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comunidades_0_OIDs);

System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> DameUsuarioPorNombre (string p_nombre);
}
}
