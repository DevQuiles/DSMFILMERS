

using System;
using System.Text;
using System.Collections.Generic;

using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
/*
 *      Definition of the class RecomendacionesCEN
 *
 */
public partial class RecomendacionesCEN
{
private IRecomendacionesRepository _IRecomendacionesRepository;

public RecomendacionesCEN(IRecomendacionesRepository _IRecomendacionesRepository)
{
        this._IRecomendacionesRepository = _IRecomendacionesRepository;
}

public IRecomendacionesRepository get_IRecomendacionesRepository ()
{
        return this._IRecomendacionesRepository;
}

public System.Collections.Generic.IList<RecomendacionesEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<RecomendacionesEN> list = null;

        list = _IRecomendacionesRepository.DameTodos (first, size);
        return list;
}
public int CrearRecomendacionDefault (Nullable<DateTime> p_fecha, string p_recomendador, string p_recomendado, int p_pelicula)
{
        RecomendacionesEN recomendacionesEN = null;
        int oid;

        //Initialized RecomendacionesEN
        recomendacionesEN = new RecomendacionesEN ();
        recomendacionesEN.Fecha = p_fecha;


        if (p_recomendador != null) {
                // El argumento p_recomendador -> Property recomendador es oid = false
                // Lista de oids id
                recomendacionesEN.Recomendador = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN ();
                recomendacionesEN.Recomendador.Email = p_recomendador;
        }


        if (p_recomendado != null) {
                // El argumento p_recomendado -> Property recomendado es oid = false
                // Lista de oids id
                recomendacionesEN.Recomendado = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN ();
                recomendacionesEN.Recomendado.Email = p_recomendado;
        }


        if (p_pelicula != -1) {
                // El argumento p_pelicula -> Property pelicula es oid = false
                // Lista de oids id
                recomendacionesEN.Pelicula = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.PeliculaEN ();
                recomendacionesEN.Pelicula.Id = p_pelicula;
        }



        oid = _IRecomendacionesRepository.CrearRecomendacionDefault (recomendacionesEN);
        return oid;
}
}
}
