
using System;
using System.Text;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;
using ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto;


/*
 * Clase Playlist:
 *
 */

namespace ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto
{
public partial class PlaylistRepository : BasicRepository, IPlaylistRepository
{
public PlaylistRepository() : base ()
{
}


public PlaylistRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PlaylistEN ReadOIDDefault (int id
                                  )
{
        PlaylistEN playlistEN = null;

        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Get (typeof(PlaylistNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PlaylistNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PlaylistEN>();
                        else
                                result = session.CreateCriteria (typeof(PlaylistNH)).List<PlaylistEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PlaylistEN playlist)
{
        try
        {
                SessionInitializeTransaction ();
                PlaylistNH playlistNH = (PlaylistNH)session.Load (typeof(PlaylistNH), playlist.Id);

                playlistNH.Nombre = playlist.Nombre;


                playlistNH.Descripcion = playlist.Descripcion;




                session.Update (playlistNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearPlaylist (PlaylistEN playlist)
{
        PlaylistNH playlistNH = new PlaylistNH (playlist);

        try
        {
                SessionInitializeTransaction ();
                if (playlist.Propietario != null) {
                        // Argumento OID y no colección.
                        playlistNH
                        .Propietario = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN), playlist.Propietario.Email);

                        playlistNH.Propietario.Playlistcreadas
                        .Add (playlistNH);
                }

                session.Save (playlistNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return playlistNH.Id;
}

public void ModificarPlaylist (PlaylistEN playlist)
{
        try
        {
                SessionInitializeTransaction ();
                PlaylistNH playlistNH = (PlaylistNH)session.Load (typeof(PlaylistNH), playlist.Id);

                playlistNH.Nombre = playlist.Nombre;


                playlistNH.Descripcion = playlist.Descripcion;

                session.Update (playlistNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPlaylist (int id
                            )
{
        try
        {
                SessionInitializeTransaction ();
                PlaylistNH playlistNH = (PlaylistNH)session.Load (typeof(PlaylistNH), id);
                session.Delete (playlistNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorOID
//Con e: PlaylistEN
public PlaylistEN DamePorOID (int id
                              )
{
        PlaylistEN playlistEN = null;

        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Get (typeof(PlaylistNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return playlistEN;
}

public System.Collections.Generic.IList<PlaylistEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PlaylistEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PlaylistNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PlaylistEN>();
                else
                        result = session.CreateCriteria (typeof(PlaylistNH)).List<PlaylistEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AsignarSuscriptor (int p_Playlist_OID, System.Collections.Generic.IList<string> p_suscriptores_OIDs)
{
        ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN playlistEN = null;
        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Load (typeof(PlaylistNH), p_Playlist_OID);
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN suscriptoresENAux = null;
                if (playlistEN.Suscriptores == null) {
                        playlistEN.Suscriptores = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN>();
                }

                foreach (string item in p_suscriptores_OIDs) {
                        suscriptoresENAux = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN ();
                        suscriptoresENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.UsuarioNH), item);
                        suscriptoresENAux.Playlistguardadas.Add (playlistEN);

                        playlistEN.Suscriptores.Add (suscriptoresENAux);
                }


                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarSuscriptor (int p_Playlist_OID, System.Collections.Generic.IList<string> p_suscriptores_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN playlistEN = null;
                playlistEN = (PlaylistEN)session.Load (typeof(PlaylistNH), p_Playlist_OID);

                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN suscriptoresENAux = null;
                if (playlistEN.Suscriptores != null) {
                        foreach (string item in p_suscriptores_OIDs) {
                                suscriptoresENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.UsuarioNH), item);
                                if (playlistEN.Suscriptores.Contains (suscriptoresENAux) == true) {
                                        playlistEN.Suscriptores.Remove (suscriptoresENAux);
                                        suscriptoresENAux.Playlistguardadas.Remove (playlistEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_suscriptores_OIDs you are trying to unrelationer, doesn't exist in PlaylistEN");
                        }
                }

                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AsignarPeliculas (int p_Playlist_OID, System.Collections.Generic.IList<int> p_peliculas_OIDs)
{
        ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN playlistEN = null;
        try
        {
                SessionInitializeTransaction ();
                playlistEN = (PlaylistEN)session.Load (typeof(PlaylistNH), p_Playlist_OID);
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN peliculasENAux = null;
                if (playlistEN.Peliculas == null) {
                        playlistEN.Peliculas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN>();
                }

                foreach (int item in p_peliculas_OIDs) {
                        peliculasENAux = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN ();
                        peliculasENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.PeliculaNH), item);
                        peliculasENAux.Playlist.Add (playlistEN);

                        playlistEN.Peliculas.Add (peliculasENAux);
                }


                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarPeliculas (int p_Playlist_OID, System.Collections.Generic.IList<int> p_peliculas_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PlaylistEN playlistEN = null;
                playlistEN = (PlaylistEN)session.Load (typeof(PlaylistNH), p_Playlist_OID);

                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN peliculasENAux = null;
                if (playlistEN.Peliculas != null) {
                        foreach (int item in p_peliculas_OIDs) {
                                peliculasENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.PeliculaNH), item);
                                if (playlistEN.Peliculas.Contains (peliculasENAux) == true) {
                                        playlistEN.Peliculas.Remove (peliculasENAux);
                                        peliculasENAux.Playlist.Remove (playlistEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_peliculas_OIDs you are trying to unrelationer, doesn't exist in PlaylistEN");
                        }
                }

                session.Update (playlistEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PlaylistRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
