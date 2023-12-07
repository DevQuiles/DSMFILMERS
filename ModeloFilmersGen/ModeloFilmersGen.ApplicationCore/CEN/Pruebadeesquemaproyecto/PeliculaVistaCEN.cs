

using System;
using System.Text;
using System.Collections.Generic;

using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
/*
 *      Definition of the class PeliculaVistaCEN
 *
 */
public partial class PeliculaVistaCEN
{
private IPeliculaVistaRepository _IPeliculaVistaRepository;

public PeliculaVistaCEN(IPeliculaVistaRepository _IPeliculaVistaRepository)
{
        this._IPeliculaVistaRepository = _IPeliculaVistaRepository;
}

public IPeliculaVistaRepository get_IPeliculaVistaRepository ()
{
        return this._IPeliculaVistaRepository;
}

public int CrearPeliculaVista (string p_comentario, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum p_valoracion, Nullable<DateTime> p_fecha, int p_pelicula, string p_usuario)
{
        PeliculaVistaEN peliculaVistaEN = null;
        int oid;

        //Initialized PeliculaVistaEN
        peliculaVistaEN = new PeliculaVistaEN ();
        peliculaVistaEN.Comentario = p_comentario;

        peliculaVistaEN.Valoracion = p_valoracion;

        peliculaVistaEN.Fecha = p_fecha;


        if (p_pelicula != -1) {
                // El argumento p_pelicula -> Property pelicula es oid = false
                // Lista de oids id
                peliculaVistaEN.Pelicula = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN ();
                peliculaVistaEN.Pelicula.Id = p_pelicula;
        }


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                peliculaVistaEN.Usuario = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN ();
                peliculaVistaEN.Usuario.Email = p_usuario;
        }



        oid = _IPeliculaVistaRepository.CrearPeliculaVista (peliculaVistaEN);
        return oid;
}

public void ModificarPeliculaVista (int p_PeliculaVista_OID, string p_comentario, ModeloFilmersGen.ApplicationCore.Enumerated.Pruebadeesquemaproyecto.EstrellasEnum p_valoracion, Nullable<DateTime> p_fecha)
{
        PeliculaVistaEN peliculaVistaEN = null;

        //Initialized PeliculaVistaEN
        peliculaVistaEN = new PeliculaVistaEN ();
        peliculaVistaEN.Id = p_PeliculaVista_OID;
        peliculaVistaEN.Comentario = p_comentario;
        peliculaVistaEN.Valoracion = p_valoracion;
        peliculaVistaEN.Fecha = p_fecha;
        //Call to PeliculaVistaRepository

        _IPeliculaVistaRepository.ModificarPeliculaVista (peliculaVistaEN);
}

public void BorrarPeliculaVista (int id
                                 )
{
        _IPeliculaVistaRepository.BorrarPeliculaVista (id);
}

public PeliculaVistaEN DamePorOID (int id
                                   )
{
        PeliculaVistaEN peliculaVistaEN = null;

        peliculaVistaEN = _IPeliculaVistaRepository.DamePorOID (id);
        return peliculaVistaEN;
}

public System.Collections.Generic.IList<PeliculaVistaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PeliculaVistaEN> list = null;

        list = _IPeliculaVistaRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaVistaEN> DameTodosMes (int? p_mes, int ? p_anyo)
{
        return _IPeliculaVistaRepository.DameTodosMes (p_mes, p_anyo);
}
}
}
