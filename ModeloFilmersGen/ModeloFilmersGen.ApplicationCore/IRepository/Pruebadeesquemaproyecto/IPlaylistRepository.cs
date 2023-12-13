
using System;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public partial interface IPlaylistRepository
{
void setSessionCP (GenericSessionCP session);

PlaylistEN ReadOIDDefault (int id
                           );

void ModifyDefault (PlaylistEN playlist);

System.Collections.Generic.IList<PlaylistEN> ReadAllDefault (int first, int size);



int CrearPlaylist (PlaylistEN playlist);

void ModificarPlaylist (PlaylistEN playlist);


void BorrarPlaylist (int id
                     );


PlaylistEN DamePorOID (int id
                       );


System.Collections.Generic.IList<PlaylistEN> DameTodos (int first, int size);


void AsignarSuscriptor (int p_Playlist_OID, System.Collections.Generic.IList<string> p_suscriptores_OIDs);

void DesasignarSuscriptor (int p_Playlist_OID, System.Collections.Generic.IList<string> p_suscriptores_OIDs);


void AsignarPeliculas (int p_Playlist_OID, System.Collections.Generic.IList<int> p_peliculas_OIDs);

void DesasignarPeliculas (int p_Playlist_OID, System.Collections.Generic.IList<int> p_peliculas_OIDs);
}
}
