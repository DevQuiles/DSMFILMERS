
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
 * Clase Pelicula:
 *
 */

namespace ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto
{
public partial class PeliculaRepository : BasicRepository, IPeliculaRepository
{
public PeliculaRepository() : base ()
{
}


public PeliculaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PeliculaEN ReadOIDDefault (int id
                                  )
{
        PeliculaEN peliculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaEN = (PeliculaEN)session.Get (typeof(PeliculaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return peliculaEN;
}

public System.Collections.Generic.IList<PeliculaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PeliculaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PeliculaEN>();
                        else
                                result = session.CreateCriteria (typeof(PeliculaNH)).List<PeliculaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaNH peliculaNH = (PeliculaNH)session.Load (typeof(PeliculaNH), pelicula.Id);

                peliculaNH.Nombre = pelicula.Nombre;


                peliculaNH.Caratula = pelicula.Caratula;


                peliculaNH.Descripcion = pelicula.Descripcion;


                peliculaNH.Fecha = pelicula.Fecha;


                peliculaNH.Genero = pelicula.Genero;


                peliculaNH.Duracion = pelicula.Duracion;






                peliculaNH.Puntuacion = pelicula.Puntuacion;


                peliculaNH.Estado = pelicula.Estado;

                session.Update (peliculaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearPelicula (PeliculaEN pelicula)
{
        PeliculaNH peliculaNH = new PeliculaNH (pelicula);

        try
        {
                SessionInitializeTransaction ();

                session.Save (peliculaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peliculaNH.Id;
}

public void ModificarPelicula (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaNH peliculaNH = (PeliculaNH)session.Load (typeof(PeliculaNH), pelicula.Id);

                peliculaNH.Nombre = pelicula.Nombre;


                peliculaNH.Caratula = pelicula.Caratula;


                peliculaNH.Descripcion = pelicula.Descripcion;


                peliculaNH.Fecha = pelicula.Fecha;


                peliculaNH.Genero = pelicula.Genero;


                peliculaNH.Duracion = pelicula.Duracion;


                peliculaNH.Puntuacion = pelicula.Puntuacion;


                peliculaNH.Estado = pelicula.Estado;

                session.Update (peliculaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPelicula (int id
                            )
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaNH peliculaNH = (PeliculaNH)session.Load (typeof(PeliculaNH), id);
                session.Delete (peliculaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorOID
//Con e: PeliculaEN
public PeliculaEN DamePorOID (int id
                              )
{
        PeliculaEN peliculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaEN = (PeliculaEN)session.Get (typeof(PeliculaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return peliculaEN;
}

public System.Collections.Generic.IList<PeliculaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PeliculaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PeliculaEN>();
                else
                        result = session.CreateCriteria (typeof(PeliculaNH)).List<PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> DamePeliculaPorNombre (string p_nombre)
{
        System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaNH self where FROM PeliculaNH  as pelicula where pelicula.Nombre like '%' + :p_nombre + '%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaNHdamePeliculaPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> DamePeliculasPorFiltro (string p_genero, int? p_anyo, int ? p_puntuacion)
{
        System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeliculaNH self where FROM PeliculaNH as pelicula WHERE (:p_genero IS NULL OR :p_genero IN ELEMENTS(pelicula.Genero)) AND (:p_anyo IS NULL OR YEAR(pelicula.Fecha) = :p_anyo) AND (:p_puntuacion IS NULL OR pelicula.Puntuacion = :p_puntuacion)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeliculaNHdamePeliculasPorFiltroHQL");
                query.SetParameter ("p_genero", p_genero);
                query.SetParameter ("p_anyo", p_anyo);
                query.SetParameter ("p_puntuacion", p_puntuacion);

                result = query.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in PeliculaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
