

using System;
using System.Text;
using System.Collections.Generic;

using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
/*
 *      Definition of the class PeliculaCEN
 *
 */
public partial class PeliculaCEN
{
private IPeliculaRepository _IPeliculaRepository;

public PeliculaCEN(IPeliculaRepository _IPeliculaRepository)
{
        this._IPeliculaRepository = _IPeliculaRepository;
}

public IPeliculaRepository get_IPeliculaRepository ()
{
        return this._IPeliculaRepository;
}

public int CrearPelicula (string p_nombre, string p_caratula, string p_descripcion, Nullable<DateTime> p_fecha, System.Collections.Generic.IList<string> p_genero, int p_duracion, int p_puntuacion, string p_estado)
{
        PeliculaEN peliculaEN = null;
        int oid;

        //Initialized PeliculaEN
        peliculaEN = new PeliculaEN ();
        peliculaEN.Nombre = p_nombre;

        peliculaEN.Caratula = p_caratula;

        peliculaEN.Descripcion = p_descripcion;

        peliculaEN.Fecha = p_fecha;

        peliculaEN.Genero = p_genero;

        peliculaEN.Duracion = p_duracion;

        peliculaEN.Puntuacion = p_puntuacion;

        peliculaEN.Estado = p_estado;



        oid = _IPeliculaRepository.CrearPelicula (peliculaEN);
        return oid;
}

public void ModificarPelicula (int p_Pelicula_OID, string p_nombre, string p_caratula, string p_descripcion, Nullable<DateTime> p_fecha, System.Collections.Generic.IList<string> p_genero, int p_duracion, int p_puntuacion, string p_estado)
{
        PeliculaEN peliculaEN = null;

        //Initialized PeliculaEN
        peliculaEN = new PeliculaEN ();
        peliculaEN.Id = p_Pelicula_OID;
        peliculaEN.Nombre = p_nombre;
        peliculaEN.Caratula = p_caratula;
        peliculaEN.Descripcion = p_descripcion;
        peliculaEN.Fecha = p_fecha;
        peliculaEN.Genero = p_genero;
        peliculaEN.Duracion = p_duracion;
        peliculaEN.Puntuacion = p_puntuacion;
        peliculaEN.Estado = p_estado;
        //Call to PeliculaRepository

        _IPeliculaRepository.ModificarPelicula (peliculaEN);
}

public void BorrarPelicula (int id
                            )
{
        _IPeliculaRepository.BorrarPelicula (id);
}

public PeliculaEN DamePorOID (int id
                              )
{
        PeliculaEN peliculaEN = null;

        peliculaEN = _IPeliculaRepository.DamePorOID (id);
        return peliculaEN;
}

public System.Collections.Generic.IList<PeliculaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PeliculaEN> list = null;

        list = _IPeliculaRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> DamePeliculaPorNombre (string p_nombre)
{
        return _IPeliculaRepository.DamePeliculaPorNombre (p_nombre);
}
public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN> DamePeliculasPorFiltro (string p_genero, int? p_anyo, int ? p_puntuacion)
{
        return _IPeliculaRepository.DamePeliculasPorFiltro (p_genero, p_anyo, p_puntuacion);
}

        public IList<PeliculaEN> DamePeliculaPorNombre()
        {
            throw new NotImplementedException();
        }
    }
}
