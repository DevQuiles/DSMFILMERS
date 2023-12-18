
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
 * Clase Comunidades:
 *
 */

namespace ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto
{
public partial class ComunidadesRepository : BasicRepository, IComunidadesRepository
{
public ComunidadesRepository() : base ()
{
}


public ComunidadesRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComunidadesEN ReadOIDDefault (int id
                                     )
{
        ComunidadesEN comunidadesEN = null;

        try
        {
                SessionInitializeTransaction ();
                comunidadesEN = (ComunidadesEN)session.Get (typeof(ComunidadesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comunidadesEN;
}

public System.Collections.Generic.IList<ComunidadesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComunidadesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComunidadesNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComunidadesEN>();
                        else
                                result = session.CreateCriteria (typeof(ComunidadesNH)).List<ComunidadesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadesRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComunidadesEN comunidades)
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadesNH comunidadesNH = (ComunidadesNH)session.Load (typeof(ComunidadesNH), comunidades.Id);

                comunidadesNH.Nombre = comunidades.Nombre;


                comunidadesNH.FechaCreacion = comunidades.FechaCreacion;


                comunidadesNH.Descripcion = comunidades.Descripcion;




                session.Update (comunidadesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearComunidad (ComunidadesEN comunidades)
{
        ComunidadesNH comunidadesNH = new ComunidadesNH (comunidades);

        try
        {
                SessionInitializeTransaction ();
                if (comunidades.Creador_Emisor != null) {
                        // Argumento OID y no colección.
                        comunidadesNH
                        .Creador_Emisor = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN), comunidades.Creador_Emisor.Email);

                        comunidadesNH.Creador_Emisor.Comunidades
                        .Add (comunidadesNH);
                }

                session.Save (comunidadesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comunidadesNH.Id;
}

public void ModificarComunidad (ComunidadesEN comunidades)
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadesNH comunidadesNH = (ComunidadesNH)session.Load (typeof(ComunidadesNH), comunidades.Id);

                comunidadesNH.Nombre = comunidades.Nombre;


                comunidadesNH.FechaCreacion = comunidades.FechaCreacion;


                comunidadesNH.Descripcion = comunidades.Descripcion;

                session.Update (comunidadesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarSoloComunidad (int id
                                 )
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadesNH comunidadesNH = (ComunidadesNH)session.Load (typeof(ComunidadesNH), id);
                session.Delete (comunidadesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorOID
//Con e: ComunidadesEN
public ComunidadesEN DamePorOID (int id
                                 )
{
        ComunidadesEN comunidadesEN = null;

        try
        {
                SessionInitializeTransaction ();
                comunidadesEN = (ComunidadesEN)session.Get (typeof(ComunidadesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return comunidadesEN;
}

public System.Collections.Generic.IList<ComunidadesEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ComunidadesEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComunidadesNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComunidadesEN>();
                else
                        result = session.CreateCriteria (typeof(ComunidadesNH)).List<ComunidadesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> DameComunidadPorNombre (string p_nombre)
{
        System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComunidadesNH self where FROM ComunidadesNH as comunidad where comunidad.Nombre like '%' + :p_nombre + '%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComunidadesNHdameComunidadPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComunidadesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
