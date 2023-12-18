
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
 * Clase Mensaje:
 *
 */

namespace ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto
{
public partial class MensajeRepository : BasicRepository, IMensajeRepository
{
public MensajeRepository() : base ()
{
}


public MensajeRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MensajeEN ReadOIDDefault (int id
                                 )
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MensajeNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                        else
                                result = session.CreateCriteria (typeof(MensajeNH)).List<MensajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), mensaje.Id);

                mensajeNH.Contenido = mensaje.Contenido;


                mensajeNH.Fecha = mensaje.Fecha;


                session.Update (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearMensaje (MensajeEN mensaje)
{
        MensajeNH mensajeNH = new MensajeNH (mensaje);

        try
        {
                SessionInitializeTransaction ();
                if (mensaje.Comunidad != null) {
                        // Argumento OID y no colección.
                        mensajeNH
                        .Comunidad = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN), mensaje.Comunidad.Id);

                        mensajeNH.Comunidad.Menesajes
                        .Add (mensajeNH);
                }

                session.Save (mensajeNH);
                session.Flush ();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajeNH.Id;
}

//Sin e: DamePorOID
//Con e: MensajeEN
public MensajeEN DamePorOID (int id
                             )
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MensajeNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                else
                        result = session.CreateCriteria (typeof(MensajeNH)).List<MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void ModificarMensaje (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), mensaje.Id);

                mensajeNH.Contenido = mensaje.Contenido;


                mensajeNH.Fecha = mensaje.Fecha;

                session.Update (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarMensaje (int id
                           )
{
        try
        {
                SessionInitializeTransaction ();
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), id);
                session.Delete (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
