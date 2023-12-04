
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
 * Clase PeliculaVista:
 *
 */

namespace ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto
{
public partial class PeliculaVistaRepository : BasicRepository, IPeliculaVistaRepository
{
public PeliculaVistaRepository() : base ()
{
}


public PeliculaVistaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PeliculaVistaEN ReadOIDDefault (int id
                                       )
{
        PeliculaVistaEN peliculaVistaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaVistaEN = (PeliculaVistaEN)session.Get (typeof(PeliculaVistaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return peliculaVistaEN;
}

public System.Collections.Generic.IList<PeliculaVistaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PeliculaVistaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PeliculaVistaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PeliculaVistaEN>();
                        else
                                result = session.CreateCriteria (typeof(PeliculaVistaNH)).List<PeliculaVistaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaVistaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PeliculaVistaEN peliculaVista)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaVistaNH peliculaVistaNH = (PeliculaVistaNH)session.Load (typeof(PeliculaVistaNH), peliculaVista.Id);

                peliculaVistaNH.Comentario = peliculaVista.Comentario;


                peliculaVistaNH.Valoracion = peliculaVista.Valoracion;


                peliculaVistaNH.Fecha = peliculaVista.Fecha;



                session.Update (peliculaVistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaVistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearPeliculaVista (PeliculaVistaEN peliculaVista)
{
        PeliculaVistaNH peliculaVistaNH = new PeliculaVistaNH (peliculaVista);

        try
        {
                SessionInitializeTransaction ();
                if (peliculaVista.Pelicula != null) {
                        // Argumento OID y no colección.
                        peliculaVistaNH
                        .Pelicula = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN), peliculaVista.Pelicula.Id);

                        peliculaVistaNH.Pelicula.PeliculasVistas
                        .Add (peliculaVistaNH);
                }
                if (peliculaVista.Usuario != null) {
                        // Argumento OID y no colección.
                        peliculaVistaNH
                        .Usuario = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN), peliculaVista.Usuario.Email);

                        peliculaVistaNH.Usuario.PeliculasVistas
                        .Add (peliculaVistaNH);
                }

                session.Save (peliculaVistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaVistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peliculaVistaNH.Id;
}

public void ModificarPeliculaVista (PeliculaVistaEN peliculaVista)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaVistaNH peliculaVistaNH = (PeliculaVistaNH)session.Load (typeof(PeliculaVistaNH), peliculaVista.Id);

                peliculaVistaNH.Fecha = peliculaVista.Fecha;

                session.Update (peliculaVistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaVistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPeliculaVista (int id
                                 )
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaVistaNH peliculaVistaNH = (PeliculaVistaNH)session.Load (typeof(PeliculaVistaNH), id);
                session.Delete (peliculaVistaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaVistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorOID
//Con e: PeliculaVistaEN
public PeliculaVistaEN DamePorOID (int id
                                   )
{
        PeliculaVistaEN peliculaVistaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaVistaEN = (PeliculaVistaEN)session.Get (typeof(PeliculaVistaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return peliculaVistaEN;
}

public System.Collections.Generic.IList<PeliculaVistaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PeliculaVistaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PeliculaVistaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PeliculaVistaEN>();
                else
                        result = session.CreateCriteria (typeof(PeliculaVistaNH)).List<PeliculaVistaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaVistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> DameTodosMes (int? p_mes, int ? p_anyo)
{
        System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaVistaNH self where FROM PeliculaVistaNH as pv Where MONTH(pv.Fecha) = :p_mes and YEAR(pv.Fecha) = :p_anyo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaVistaNHdameTodosMesHQL");
                query.SetParameter ("p_mes", p_mes);
                query.SetParameter ("p_anyo", p_anyo);

                result = query.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaVistaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
