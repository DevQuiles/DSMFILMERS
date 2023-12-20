
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
 * Clase Usuario:
 *
 */

namespace ModeloFilmersGen.Infraestructure.Repository.Pruebadeesquemaproyecto
{
public partial class UsuarioRepository : BasicRepository, IUsuarioRepository
{
public UsuarioRepository() : base ()
{
}


public UsuarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public UsuarioEN ReadOIDDefault (string email
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), email);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.Email);

                usuarioNH.NomUsuario = usuario.NomUsuario;


                usuarioNH.Nombre = usuario.Nombre;


                usuarioNH.FechaNac = usuario.FechaNac;


                usuarioNH.Localidad = usuario.Localidad;


                usuarioNH.Pais = usuario.Pais;












                usuarioNH.Nivel = usuario.Nivel;



                usuarioNH.Pass = usuario.Pass;


                usuarioNH.RecompensaDisponible = usuario.RecompensaDisponible;


                usuarioNH.AvatarIcon = usuario.AvatarIcon;


                usuarioNH.UsuarioGoogle = usuario.UsuarioGoogle;

                session.Update (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string CrearUsuario (UsuarioEN usuario)
{
        UsuarioNH usuarioNH = new UsuarioNH (usuario);

        try
        {
                SessionInitializeTransaction ();

                session.Save (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioNH.Email;
}

public void ModificarUsuario (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.Email);

                usuarioNH.NomUsuario = usuario.NomUsuario;


                usuarioNH.Nombre = usuario.Nombre;


                usuarioNH.FechaNac = usuario.FechaNac;


                usuarioNH.Localidad = usuario.Localidad;


                usuarioNH.Pais = usuario.Pais;


                usuarioNH.Nivel = usuario.Nivel;


                usuarioNH.Pass = usuario.Pass;


                usuarioNH.RecompensaDisponible = usuario.RecompensaDisponible;


                usuarioNH.AvatarIcon = usuario.AvatarIcon;


                usuarioNH.UsuarioGoogle = usuario.UsuarioGoogle;

                session.Update (usuarioNH);
                SessionCommit ();
                session.Flush();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarUsuario (string email
                           )
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), email);
                session.Delete (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorOID
//Con e: UsuarioEN
public UsuarioEN DamePorOID (string email
                             )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), email);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AsignarPeliculaWatchList (string p_Usuario_OID, System.Collections.Generic.IList<int> p_deseadas_OIDs)
{
        ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN deseadasENAux = null;
                if (usuarioEN.Deseadas == null) {
                        usuarioEN.Deseadas = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN>();
                }

                foreach (int item in p_deseadas_OIDs) {
                        deseadasENAux = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN ();
                        deseadasENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.PeliculaNH), item);
                        deseadasENAux.Usuarios.Add (usuarioEN);

                        usuarioEN.Deseadas.Add (deseadasENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarPeliculaWatchList (string p_Usuario_OID, System.Collections.Generic.IList<int> p_deseadas_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);

                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN deseadasENAux = null;
                if (usuarioEN.Deseadas != null) {
                        foreach (int item in p_deseadas_OIDs) {
                                deseadasENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.PeliculaNH), item);
                                if (usuarioEN.Deseadas.Contains (deseadasENAux) == true) {
                                        usuarioEN.Deseadas.Remove (deseadasENAux);
                                        deseadasENAux.Usuarios.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_deseadas_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AsignarSeguidores (string p_Usuario_OID, System.Collections.Generic.IList<string> p_seguidores_OIDs)
{
        ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN seguidoresENAux = null;
                if (usuarioEN.Seguidores == null) {
                        usuarioEN.Seguidores = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN>();
                }

                foreach (string item in p_seguidores_OIDs) {
                        seguidoresENAux = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN ();
                        seguidoresENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.UsuarioNH), item);
                        seguidoresENAux.Seguidos.Add (usuarioEN);

                        usuarioEN.Seguidores.Add (seguidoresENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarSeguidores (string p_Usuario_OID, System.Collections.Generic.IList<string> p_seguidores_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);

                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN seguidoresENAux = null;
                if (usuarioEN.Seguidores != null) {
                        foreach (string item in p_seguidores_OIDs) {
                                seguidoresENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.UsuarioNH), item);
                                if (usuarioEN.Seguidores.Contains (seguidoresENAux) == true) {
                                        usuarioEN.Seguidores.Remove (seguidoresENAux);
                                        seguidoresENAux.Seguidos.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_seguidores_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AsignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comunidades_0_OIDs)
{
        ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN comunidades_0ENAux = null;
                if (usuarioEN.Comunidades_0 == null) {
                        usuarioEN.Comunidades_0 = new System.Collections.Generic.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN>();
                }

                foreach (int item in p_comunidades_0_OIDs) {
                        comunidades_0ENAux = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN ();
                        comunidades_0ENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.ComunidadesNH), item);
                        comunidades_0ENAux.Usuario.Add (usuarioEN);

                        usuarioEN.Comunidades_0.Add (comunidades_0ENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarComunidad (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comunidades_0_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioNH), p_Usuario_OID);

                ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN comunidades_0ENAux = null;
                if (usuarioEN.Comunidades_0 != null) {
                        foreach (int item in p_comunidades_0_OIDs) {
                                comunidades_0ENAux = (ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN)session.Load (typeof(ModeloFilmersGen.Infraestructure.EN.Pruebadeesquemaproyecto.ComunidadesNH), item);
                                if (usuarioEN.Comunidades_0.Contains (comunidades_0ENAux) == true) {
                                        usuarioEN.Comunidades_0.Remove (comunidades_0ENAux);
                                        comunidades_0ENAux.Usuario.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_comunidades_0_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> DameUsuarioPorNombre (string p_nombre)
{
        System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioNH self where FROM UsuarioNH as user where user.NomUsuario like '%' + :p_nombre + '%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioNHdameUsuarioPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ModeloFilmersGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new ModeloFilmersGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
