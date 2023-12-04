
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
 * Clase Recomendaciones:
 *
 */

namespace ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto
{
public partial class RecomendacionesRepository : BasicRepository, IRecomendacionesRepository
{
public RecomendacionesRepository() : base ()
{
}


public RecomendacionesRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public RecomendacionesEN ReadOIDDefault (int id
                                         )
{
        RecomendacionesEN recomendacionesEN = null;

        try
        {
                SessionInitializeTransaction ();
                recomendacionesEN = (RecomendacionesEN)session.Get (typeof(RecomendacionesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return recomendacionesEN;
}

public System.Collections.Generic.IList<RecomendacionesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RecomendacionesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RecomendacionesNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<RecomendacionesEN>();
                        else
                                result = session.CreateCriteria (typeof(RecomendacionesNH)).List<RecomendacionesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in RecomendacionesRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RecomendacionesEN recomendaciones)
{
        try
        {
                SessionInitializeTransaction ();
                RecomendacionesNH recomendacionesNH = (RecomendacionesNH)session.Load (typeof(RecomendacionesNH), recomendaciones.Id);

                recomendacionesNH.Fecha = recomendaciones.Fecha;




                session.Update (recomendacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in RecomendacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public System.Collections.Generic.IList<RecomendacionesEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<RecomendacionesEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RecomendacionesNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<RecomendacionesEN>();
                else
                        result = session.CreateCriteria (typeof(RecomendacionesNH)).List<RecomendacionesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in RecomendacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int CrearRecomendacionDefault (RecomendacionesEN recomendaciones)
{
        RecomendacionesNH recomendacionesNH = new RecomendacionesNH (recomendaciones);

        try
        {
                SessionInitializeTransaction ();
                if (recomendaciones.Recomendador != null) {
                        // Argumento OID y no colección.
                        recomendacionesNH
                        .Recomendador = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN), recomendaciones.Recomendador.Email);

                        recomendacionesNH.Recomendador.Recomendaciones_Hechas
                        .Add (recomendacionesNH);
                }
                if (recomendaciones.Recomendado != null) {
                        // Argumento OID y no colección.
                        recomendacionesNH
                        .Recomendado = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN), recomendaciones.Recomendado.Email);

                        recomendacionesNH.Recomendado.Recomendaciones_Recibidas
                        .Add (recomendacionesNH);
                }
                if (recomendaciones.Pelicula != null) {
                        // Argumento OID y no colección.
                        recomendacionesNH
                        .Pelicula = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN), recomendaciones.Pelicula.Id);

                        recomendacionesNH.Pelicula.Recomendaciones
                        .Add (recomendacionesNH);
                }

                session.Save (recomendacionesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in RecomendacionesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return recomendacionesNH.Id;
}
}
}
