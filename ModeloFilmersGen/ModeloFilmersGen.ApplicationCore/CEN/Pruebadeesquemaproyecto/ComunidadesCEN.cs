

using System;
using System.Text;
using System.Collections.Generic;

using ModeloFilmersGen.ApplicationCore.Exceptions;

using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;


namespace ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto
{
/*
 *      Definition of the class ComunidadesCEN
 *
 */
public partial class ComunidadesCEN
{
private IComunidadesRepository _IComunidadesRepository;

public ComunidadesCEN(IComunidadesRepository _IComunidadesRepository)
{
        this._IComunidadesRepository = _IComunidadesRepository;
}

public IComunidadesRepository get_IComunidadesRepository ()
{
        return this._IComunidadesRepository;
}

public int CrearComunidad (string p_nombre, Nullable<DateTime> p_fechaCreacion, string p_descripcion, string p_creador_Emisor)
{
        ComunidadesEN comunidadesEN = null;
        int oid;

        //Initialized ComunidadesEN
        comunidadesEN = new ComunidadesEN ();
        comunidadesEN.Nombre = p_nombre;

        comunidadesEN.FechaCreacion = p_fechaCreacion;

        comunidadesEN.Descripcion = p_descripcion;


        if (p_creador_Emisor != null) {
                // El argumento p_creador_Emisor -> Property creador_Emisor es oid = false
                // Lista de oids id
                comunidadesEN.Creador_Emisor = new ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.UsuarioEN ();
                comunidadesEN.Creador_Emisor.Email = p_creador_Emisor;
        }



        oid = _IComunidadesRepository.CrearComunidad (comunidadesEN);
        return oid;
}

public void ModificarComunidad (int p_Comunidades_OID, string p_nombre, Nullable<DateTime> p_fechaCreacion, string p_descripcion)
{
        ComunidadesEN comunidadesEN = null;

        //Initialized ComunidadesEN
        comunidadesEN = new ComunidadesEN ();
        comunidadesEN.Id = p_Comunidades_OID;
        comunidadesEN.Nombre = p_nombre;
        comunidadesEN.FechaCreacion = p_fechaCreacion;
        comunidadesEN.Descripcion = p_descripcion;
        //Call to ComunidadesRepository

        _IComunidadesRepository.ModificarComunidad (comunidadesEN);
}

public void BorrarComunidad (int id
                             )
{
        _IComunidadesRepository.BorrarComunidad (id);
}

public ComunidadesEN DamePorOID (int id
                                 )
{
        ComunidadesEN comunidadesEN = null;

        comunidadesEN = _IComunidadesRepository.DamePorOID (id);
        return comunidadesEN;
}

public System.Collections.Generic.IList<ComunidadesEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ComunidadesEN> list = null;

        list = _IComunidadesRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> DameComunidadPorNombre (string p_nombre)
{
        return _IComunidadesRepository.DameComunidadPorNombre (p_nombre);
}
}
}
