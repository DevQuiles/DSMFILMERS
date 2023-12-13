

using System;
using System.Text;
using System.Collections.Generic;

using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
/*
 *      Definition of the class PlaylistCEN
 *
 */
public partial class PlaylistCEN
{
private IPlaylistRepository _IPlaylistRepository;

public PlaylistCEN(IPlaylistRepository _IPlaylistRepository)
{
        this._IPlaylistRepository = _IPlaylistRepository;
}

public IPlaylistRepository get_IPlaylistRepository ()
{
        return this._IPlaylistRepository;
}

public int CrearPlaylist (string p_nombre, string p_descripcion, string p_propietario)
{
        PlaylistEN playlistEN = null;
        int oid;

        //Initialized PlaylistEN
        playlistEN = new PlaylistEN ();
        playlistEN.Nombre = p_nombre;

        playlistEN.Descripcion = p_descripcion;


        if (p_propietario != null) {
                // El argumento p_propietario -> Property propietario es oid = false
                // Lista de oids id
                playlistEN.Propietario = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN ();
                playlistEN.Propietario.Email = p_propietario;
        }



        oid = _IPlaylistRepository.CrearPlaylist (playlistEN);
        return oid;
}

public void ModificarPlaylist (int p_Playlist_OID, string p_nombre, string p_descripcion)
{
        PlaylistEN playlistEN = null;

        //Initialized PlaylistEN
        playlistEN = new PlaylistEN ();
        playlistEN.Id = p_Playlist_OID;
        playlistEN.Nombre = p_nombre;
        playlistEN.Descripcion = p_descripcion;
        //Call to PlaylistRepository

        _IPlaylistRepository.ModificarPlaylist (playlistEN);
}

public void BorrarPlaylist (int id
                            )
{
        _IPlaylistRepository.BorrarPlaylist (id);
}

public PlaylistEN DamePorOID (int id
                              )
{
        PlaylistEN playlistEN = null;

        playlistEN = _IPlaylistRepository.DamePorOID (id);
        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> list = null;

        list = _IPlaylistRepository.DameTodos (first, size);
        return list;
}
public void AsignarSuscriptor (int p_Playlist_OID, System.Collections.Generic.IList<string> p_suscriptores_OIDs)
{
        //Call to PlaylistRepository

        _IPlaylistRepository.AsignarSuscriptor (p_Playlist_OID, p_suscriptores_OIDs);
}
public void DesasignarSuscriptor (int p_Playlist_OID, System.Collections.Generic.IList<string> p_suscriptores_OIDs)
{
        //Call to PlaylistRepository

        _IPlaylistRepository.DesasignarSuscriptor (p_Playlist_OID, p_suscriptores_OIDs);
}
public void AsignarPeliculas (int p_Playlist_OID, System.Collections.Generic.IList<int> p_peliculas_OIDs)
{
        //Call to PlaylistRepository

        _IPlaylistRepository.AsignarPeliculas (p_Playlist_OID, p_peliculas_OIDs);
}
public void DesasignarPeliculas (int p_Playlist_OID, System.Collections.Generic.IList<int> p_peliculas_OIDs)
{
        //Call to PlaylistRepository

        _IPlaylistRepository.DesasignarPeliculas (p_Playlist_OID, p_peliculas_OIDs);
}
}
}
