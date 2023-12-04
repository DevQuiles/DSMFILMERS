
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
 * Clase Notificaciones:
 *
 */

namespace ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto
{
public partial class NotificacionesRepository : BasicRepository, INotificacionesRepository
{
public NotificacionesRepository() : base ()
{
}


public NotificacionesRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public NotificacionesEN ReadOIDDefault (int id
                                        )
{
        NotificacionesEN notificacionesEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionesEN = (NotificacionesEN)session.Get (typeof(NotificacionesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return notificacionesEN;
}

public System.Collections.Generic.IList<NotificacionesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionesNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionesEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionesNH)).List<NotificacionesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionesEN notificaciones)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionesNH notificacionesNH = (NotificacionesNH)session.Load (typeof(NotificacionesNH), notificaciones.Id);

                notificacionesNH.Contenido = notificaciones.Contenido;



                notificacionesNH.Fecha = notificaciones.Fecha;


                notificacionesNH.Estado = notificaciones.Estado;


                notificacionesNH.Destacada = notificaciones.Destacada;

                session.Update (notificacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearNotificacion (NotificacionesEN notificaciones)
{
        NotificacionesNH notificacionesNH = new NotificacionesNH (notificaciones);

        try
        {
                SessionInitializeTransaction ();
                if (notificaciones.Usuario != null) {
                        // Argumento OID y no colección.
                        notificacionesNH
                        .Usuario = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN), notificaciones.Usuario.Email);

                        notificacionesNH.Usuario.Notificaciones
                        .Add (notificacionesNH);
                }

                session.Save (notificacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionesNH.Id;
}

//Sin e: DamePorOID
//Con e: NotificacionesEN
public NotificacionesEN DamePorOID (int id
                                    )
{
        NotificacionesEN notificacionesEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionesEN = (NotificacionesEN)session.Get (typeof(NotificacionesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return notificacionesEN;
}

public void ModificarNotificacion (NotificacionesEN notificaciones)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionesNH notificacionesNH = (NotificacionesNH)session.Load (typeof(NotificacionesNH), notificaciones.Id);

                notificacionesNH.Contenido = notificaciones.Contenido;


                notificacionesNH.Fecha = notificaciones.Fecha;


                notificacionesNH.Estado = notificaciones.Estado;


                notificacionesNH.Destacada = notificaciones.Destacada;

                session.Update (notificacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<NotificacionesEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<NotificacionesEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionesNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionesEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionesNH)).List<NotificacionesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in NotificacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
